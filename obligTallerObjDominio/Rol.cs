using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class Rol : ISerializable
    {
        #region Atributos
        private string nomRol;
        private double valorHora;
        #endregion

        #region Propiedades
        public string NomRol
        {
            get { return nomRol; }
        }

        public double ValorHora
        {
            get { return this.valorHora; }
        }
        #endregion

        #region Constructor
        public Rol(string nomRol, double valorHora)
        {
            this.nomRol = nomRol;
            this.valorHora = valorHora;
        }
        #endregion

        #region Metodos


        #endregion

        #region MetodoSerilaizacion
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("nomRol", this.nomRol, typeof(string));
            info.AddValue("valorHora", this.valorHora, typeof(double));
        }
        public Rol(SerializationInfo info, StreamingContext context)
        {


            this.nomRol = (string)info.GetValue("nomRol", typeof(string));
            this.valorHora = (double)info.GetValue("valorHora", typeof(double));
        }
        #endregion
    }
}
