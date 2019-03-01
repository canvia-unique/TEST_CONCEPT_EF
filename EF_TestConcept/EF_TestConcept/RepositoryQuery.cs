using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace EF_TestConcept
{
    public class RepositoryQuery<TEntity> : IRepositoryQuery<TEntity> where TEntity : Entity
    {
        #region Properties
        private readonly IDbContext dBContext;
        private readonly bool autoSave;

        private IDbSet<TEntity> Entities
        {
            get { return this.dBContext.Set<TEntity>(); }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor que permite inicializar el context
        /// </summary>
        /// <param name="context">Contexto de la Conexión</param>
        public RepositoryQuery(IDbContext context)
        {
            this.dBContext = context;
            this.autoSave = true;

        }
        /// <summary>
        /// Repository Query 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="autoSave"></param>
        public RepositoryQuery(IDbContext context, bool autoSave)
        {
            this.dBContext = context;
            this.autoSave = autoSave;
        }
        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public RepositoryQuery()
        {
            try
            {
                this.dBContext = new DataBaseContext();
                this.autoSave = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region Operations
        /// <summary>
        /// Permite adicionar una entidad al repositorio
        /// </summary>
        /// <param name="item">entidad</param>
        public void Add(TEntity item)
        {
            try
            {
                Entities.Add(item);
                if (this.autoSave)
                {
                    dBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Permite adicionar una lista de entidades al repositorio
        /// </summary>
        /// <param name="list">lista de entidades</param>
        public void AddRange(List<TEntity> list)
        {
            try
            {
                foreach (var item in list)
                {
                    Entities.Add(item);
                }
                if (this.autoSave)
                {
                    dBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Permite actualizar una entidad del repositorio
        /// </summary>
        /// <param name="item">entidad</param>
        public void Modify(TEntity item)
        {
            try
            {
                Entities.Attach(item);
                dBContext.GetEntry(item).State = System.Data.Entity.EntityState.Modified;
                if (this.autoSave)
                {
                    dBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Permite remover una entidad del repositorio
        /// </summary>
        /// <param name="item">entidad</param>
        public void Remove(TEntity item)
        {
            try
            {
                Entities.Remove(item);
                if (this.autoSave)
                {
                    dBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Permite persistir los cambios del repositorio en la contexto y base de datos
        /// </summary>
        public void SaveChange()
        {
            try
            {
                dBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Permite realizar la combinacion de entidades
        /// </summary>
        /// <param name="persisted">entidad a persistir</param>
        /// <param name="current">entidad a proveer</param>
        public void Merge(TEntity persisted, TEntity current)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permite obtener una entidad
        /// </summary>
        /// <param name="keyValues">valores de busqueda</param>
        public TEntity Get(object keyValues)
        {
            return Entities.Find(keyValues);
        }

        /// <summary>
        /// Permite obtener el listado total de entidades
        /// </summary>
        /// <param name="includes">entidades a incluir</param>
        public List<TEntity> GetAll(List<string> includes)
        {
            return Entities.ToList();
        }

        /// <summary>
        /// Permite obtener el listado de entidades
        /// </summary>
        ///<param name="filter">filtros que definen el universo de entidades</param>
        ///<param name="orderBy">campo a aplicar el ordenamiento</param>
        ///<param name="includeProperties">entidades a incluir</param>
        ///<param name="asNoTracking">Indicador para aplicar AsNoTracking</param>
        ///<param name="estadoRegistro">Estado del registro</param>
        ///<returns>Lista de entidades</returns>
        public virtual IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, IEnumerable<string> includeProperties = null, bool asNoTracking = false, string estadoRegistro = "1")
        {

            IQueryable<TEntity> query = Entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //if (estadoRegistro != null)
            //{
            //    query = query.Where(e => e.EstadoRegistro == estadoRegistro);
            //}

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        /// <summary>
        /// Permite obtener Queryble del repositorio
        /// </summary>
        ///<param name="filter">filtros que definen el universo de entidades</param>
        ///<param name="orderBy">campo a aplicar el ordenamiento</param>
        ///<param name="includeProperties">entidades a incluir</param>
        ///<param name="asNoTracking">Indicador para aplicar AsNoTracking</param>
        ///<param name="estadoRegistro">Estado del registro</param>
        ///<returns>Queryble del repositorio</returns>
        public virtual IQueryable<TEntity> GetQueryable(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, IEnumerable<string> includeProperties = null, bool asNoTracking = false, string estadoRegistro = "1")
        {
            IQueryable<TEntity> query = Entities;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //if (estadoRegistro != null)
            //{
            //    query = query.Where(e => e.EstadoRegistro == estadoRegistro);
            //}

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        /// <summary>
        /// Destruye y libera el objeto
        /// </summary>
        public void Dispose()
        {
            if (dBContext != null && this.autoSave)
            {
                dBContext.Dispose();
            }
        }
        #endregion

    }

}