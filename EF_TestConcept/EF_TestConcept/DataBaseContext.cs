using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace EF_TestConcept
{
    public class DataBaseContext : DbContext, IDbContext
    {
        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public DataBaseContext()
            : base("FinancieroConnectionString")
        {
            //Error_PYF_C6S4_Inicio
            Database.SetInitializer<DataBaseContext>(null);
            //Error_PYF_C6S4_Fin
            this.Database.CommandTimeout = 2400;
        }

        /// <summary>
        /// Permite la actualización del repositorio de la entidad
        /// </summary>
        /// <returns>Repositorio de la entidad</returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }


        /// <summary>
        /// Permite la obtención del repositorio de la entidad
        /// </summary>
        /// <typeparam name="TEntity">Tipo de Entidad</typeparam>
        /// <param name="entity">Entidad</param>
        /// <returns>Repositorio de la entidad</returns>
        public DbEntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class
        {
            return this.Entry(entity);
        }

        /// <summary>
        /// Permite la generación del modelo de las entidades según el mapeo de entidades
        /// </summary>
        /// <param name="modelBuilder">Modelo Contructor</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes();
            //.Where(type => !String.IsNullOrEmpty(type.Namespace))
            //.Where(type => type.BaseType != null && type.BaseType.IsGenericType );
            foreach (var type in typesToRegister)
            {
                if (type.Name != "COLABORADORMAPPING")
                    continue;
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }


            base.OnModelCreating(modelBuilder);
        }
    }



}