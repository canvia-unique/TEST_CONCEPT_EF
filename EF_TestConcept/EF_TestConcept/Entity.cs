using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace EF_TestConcept
{
    [DataContract(IsReference = true)]
    public abstract class Entity : INotifyPropertyChanged, ICloneable
    {
        #region Properties

        ///// <summary>
        ///// Estado Registro
        ///// </summary>
        //public string EstadoRegistro { get; set; }
        ///// <summary>
        ///// Usuario Creación
        ///// </summary>
        //public string UsuarioCreacion { get; set; }
        ///// <summary>
        ///// Fecha Creación 
        ///// </summary>
        //public DateTime FechaCreacion { get; set; }
        ///// <summary>
        ///// Terminal Creación 
        ///// </summary>
        //public string TerminalCreacion { get; set; }
        ///// <summary>
        ///// Usuario Modificación
        ///// </summary>
        //public string UsuarioModificacion { get; set; }
        ///// <summary>
        ///// Fecha Modificación 
        ///// </summary>
        //public DateTime? FechaModificacion { get; set; }
        ///// <summary>
        ///// Terminal Modificación
        ///// </summary>
        //public string TerminalModificacion { get; set; }
        #endregion

        #region Public Methods

        /// <summary>
        /// Método que permite clonar la Entidad
        /// </summary>
        /// <returns> Entidad </returns>
        public T Clone<T>()
        {
            T copia;
            var serializer = new DataContractSerializer(typeof(T));

            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, this);
                ms.Position = 0;
                copia = (T)serializer.ReadObject(ms);
            }

            return copia;
        }

        /// <summary>
        ///  Método que permite clonar la Entidad
        /// </summary>
        /// <returns> Entidad </returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        /// <summary>
        /// Metodo Enumerado de Caracteres
        /// </summary>
        /// <typeparam name="TValue">Tipo Valor</typeparam>
        /// <param name="propertiesId">Id Propiedad</param>
        /// <returns>Lista de Caracteres</returns>
        public static IEnumerable<string> GetPropertyName<TValue>(params Expression<Func<TValue, object>>[] propertiesId)
        {
            var result = propertiesId.Select(p => p.Body is UnaryExpression ? ((MemberExpression)((UnaryExpression)p.Body).Operand).Member.Name : ((MemberExpression)p.Body).Member.Name);
            return result;
        }
        #endregion

        #region Overrides Methods
        /// <summary>
        /// 
        /// </summary>
        /// <returns>  </returns>
        /// <summary>
        /// Método que permite comparar dos entidades
        /// </summary>
        /// <param name="left">Izquierda</param>
        /// <param name="right">Derecha</param>
        /// <returns>indicador de igualdad</returns>
        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
            { return (Equals(right, null)) ? true : false; }
            else
            { return left.Equals(right); }
        }
        /// <summary>
        /// Método que permite comparar dos entidades
        /// </summary>
        /// <returns> Indicador de igualdad </returns>
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        #endregion

        #region INotifyPropertyChanged Members
        /// <summary>
        /// Propiedad de cambio
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifica cambio en la propiedad
        /// </summary>
        /// <param name="propertyName">Nombre de Propiedad</param>
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }

        #endregion
    }

}
