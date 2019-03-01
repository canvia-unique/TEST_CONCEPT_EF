using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_TestConcept
{
    class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                //Raw SQL Queries
                var result = new ReadManager().Get();
                //Linq-to-Entities
                var result2 = new COLABORADOR().Get();
                Console.WriteLine("...procesando...");
            }
        }


    }

    public class ReadManager : IReadManager
    {

        public ReadManager rm { get; set; }
        public long CODIGO_COLABORADOR { get; set; }
        public string CODIGO_INTERNO { get; set; }
        public DateTime ?FECHA_COMPORTAMIENTO_PAGO { get; set; }
        public string CODIGO_INDICADOR_CUMPLIMIENTO { get; set; }
        public string MOTIVO_MODIFICACION { get; set; }
        public string OBSERVACION { get; set; }
        public int DIAS_SUSPENSION { get; set; }
        public decimal PUNTAJE { get; set; }
        public DateTime ?FECHA_PAGO_DEUDA_VENCIDA { get; set; }
        public bool BLOQUEO_COMERCIAL { get; set; }
        public string USUARIO_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string TERMINAL_CREACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
        public DateTime  ?FECHA_MODIFICACION { get; set; }
        public string TERMINAL_MODIFICACION { get; set; }
        public DateTime ?FECHA_ULTIMO_PEDIDO { get; set; }
        public string FILLER1 { get; set; }
        public string FILLER2 { get; set; }
        public string FILLER3 { get; set; }
        public string FILLER4 { get; set; }
        public string FILLER5 { get; set; }
        public string PERFILCOBRANZA { get; set; }
        public string FIELD1 { get; set; }
        public string FIELD2 { get; set; }
        public string FIELD3 { get; set; }
        public string FIELD4 { get; set; }
        public string FIELD5 { get; set; }
        public string FIELD6 { get; set; }
        public string FIELD7 { get; set; }
        public string FIELD8 { get; set; }
        public string FIELD9 { get; set; }
        public string FIELD10 { get; set; }
        public string FIELD11 { get; set; }

        public ReadManager()
        {

            dBContext = new DataBaseContext();
        }
        private readonly DbContext dBContext = null;
        public IEnumerable<ReadManager> Get()
        {          
            object[] parameters = { };
            dBContext.Database.CommandTimeout = 1200;
            return dBContext.Database.SqlQuery<ReadManager>("USP_EF_CONCEPT_SELECT", parameters).ToList();
        }

      
    }

    public interface IReadManager
    {
        IEnumerable<ReadManager> Get();
    }

    public class COLABORADORMAPPING : BaseMapping<COLABORADOR>
    {
      
            /// <summary>
            /// Constructor por Defecto de implementación de la clase
            /// </summary>
            public COLABORADORMAPPING()
                : base()
            {
                ToTable("COLABORADOR", "GRL");
                HasKey(X => X.CODIGO_COLABORADOR);
                this.Property(t => t.CODIGO_INDICADOR_CUMPLIMIENTO).HasColumnName("CODIGO_INDICADOR_CUMPLIMIENTO");
                this.Property(t => t.CODIGO_INTERNO).HasColumnName("CODIGO_INTERNO");
                this.Property(t=>t.FECHA_COMPORTAMIENTO_PAGO).HasColumnName("FECHA_COMPORTAMIENTO_PAGO");
                this.Property(t=>t.MOTIVO_MODIFICACION).HasColumnName("MOTIVO_MODIFICACION");
                this.Property(t=>t.OBSERVACION).HasColumnName("OBSERVACION");
                this.Property(t=>t.DIAS_SUSPENSION).HasColumnName("DIAS_SUSPENSION");
                this.Property(t=>t.PUNTAJE).HasColumnName("PUNTAJE");
                this.Property(t=>t.FECHA_PAGO_DEUDA_VENCIDA).HasColumnName("FECHA_PAGO_DEUDA_VENCIDA");
                this.Property(t=>t.BLOQUEO_COMERCIAL).HasColumnName("BLOQUEO_COMERCIAL");
                this.Property(t=>t.USUARIO_CREACION).HasColumnName("USUARIO_CREACION");
                this.Property(t=>t.FECHA_CREACION).HasColumnName("FECHA_CREACION");
                this.Property(t=>t.TERMINAL_CREACION).HasColumnName("TERMINAL_CREACION");
                this.Property(t=>t.USUARIO_MODIFICACION).HasColumnName("USUARIO_MODIFICACION");
                this.Property(t=>t.FECHA_MODIFICACION).HasColumnName("FECHA_MODIFICACION");
                this.Property(t=>t.TERMINAL_MODIFICACION).HasColumnName("TERMINAL_MODIFICACION");
                this.Property(t=>t.FECHA_ULTIMO_PEDIDO).HasColumnName("FECHA_ULTIMO_PEDIDO");
                this.Property(t=>t.FILLER1).HasColumnName("FILLER1");
                this.Property(t=>t.FILLER2).HasColumnName("FILLER2");
                this.Property(t=>t.FILLER3).HasColumnName("FILLER3");
                this.Property(t=>t.FILLER4).HasColumnName("FILLER4");
                this.Property(t=>t.FILLER5).HasColumnName("FILLER5");
                this.Property(t=>t.PERFILCOBRANZA).HasColumnName("PERFILCOBRANZA");






        }
    }

    public class BaseMapping<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        public BaseMapping()
        {
    
        }
    }

    public class COLABORADOR : Entity, ICOLABORADOR
    {
        private readonly IRepositoryQuery<COLABORADOR> colaboradorRepositoryQuery;
        //public ReadManager rm { get; set; }
        public long CODIGO_COLABORADOR { get; set; }
        public string CODIGO_INTERNO { get; set; }       
        public string CODIGO_INDICADOR_CUMPLIMIENTO { get; set; }
        public DateTime? FECHA_COMPORTAMIENTO_PAGO { get; set; }
        public string MOTIVO_MODIFICACION { get; set; }
        public string OBSERVACION { get; set; }
        public int? DIAS_SUSPENSION { get; set; }
        public decimal ? PUNTAJE { get; set; }
        public DateTime? FECHA_PAGO_DEUDA_VENCIDA { get; set; }
        public bool BLOQUEO_COMERCIAL { get; set; }
        public string USUARIO_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string TERMINAL_CREACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
        public DateTime? FECHA_MODIFICACION { get; set; }
        public string TERMINAL_MODIFICACION { get; set; }
        public DateTime? FECHA_ULTIMO_PEDIDO { get; set; }
        public string FILLER1 { get; set; }
        public string FILLER2 { get; set; }
        public string FILLER3 { get; set; }
        public string FILLER4 { get; set; }
        public string FILLER5 { get; set; }
        public string PERFILCOBRANZA { get; set; }

        [NotMapped]
        public string NOMAPEADO { get; set; }

        public COLABORADOR()
        {

            dBContext = new DataBaseContext();
            colaboradorRepositoryQuery = new RepositoryQuery<COLABORADOR>();


        }
        private readonly DbContext dBContext = null;
        public IEnumerable<COLABORADOR> Get()
        {
          var result =  colaboradorRepositoryQuery.Get(x=>x.CODIGO_INTERNO == "9");
            return result;
        }


    }

    public interface ICOLABORADOR
    {
        IEnumerable<COLABORADOR> Get();
    }
}
