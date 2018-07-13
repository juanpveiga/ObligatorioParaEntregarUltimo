using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class Lugar : ISerializable
    {
        #region Atributos
        private string nomLugar;
        private string direccion;
        private bool baja;
        #endregion

        #region propiedades
        public string NomLugar 
        {
            get
            {
                return this.nomLugar;
            }
        }

        public string Direccion
        {
            get { return this.direccion; }
        }

        public bool Baja
        {
            get
            {
                return this.baja;
            }
        }
        #endregion

        #region Constructor
        public Lugar(string nomLugar, string direccion)
        {
            this.nomLugar = nomLugar;
            this.direccion = direccion;
            this.baja = false;
        }
        #endregion

        #region Metodos

        public bool bajaLugar()
        {
            return this.baja = true;
        }

        public void editarLugar (string nombre, string direccion)
        {
           
                this.nomLugar = nombre;
                this.direccion = direccion;
                

        }
        #endregion

        #region metodoSerializacion
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("nomLugar", this.nomLugar, typeof(string));
            info.AddValue("direccion", this.direccion, typeof(string));


        }
        public Lugar(SerializationInfo info, StreamingContext context)
        {


            this.nomLugar = (string)info.GetValue("nomLugar", typeof(string));
            this.direccion = (string)info.GetValue("direccion", typeof(string));
        }
            #endregion
        }
    }
