    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class Usuario : ISerializable
    {
        #region Atributos
        private string cedula;
        private string contraseña;
        private string primerNom;
        private string segundoNom;
        private string primerAp;
        private string segundoAp;
        private string email;
        private string direccion;
        private string telefono;
        private string perfil;
        #endregion

        #region Propiedades

        public string Cedula
        {
            get
            {
                return this.cedula;
            }
        }

        public string Contraseña
        {
            get { return this.contraseña; }
        }

        public string Perfil
        {
            get { return this.perfil; }
        }

        public string PrimerNom
        {
            get { return this.primerNom; }
        }

        public string PrimerAp
        {
            get { return this.primerAp; }
        }
        #endregion

        #region Constructor
        public Usuario(string cedula, string contraseña, string primerNom, string segundoNom, string primerAp, string segundoAp, 
            string email, string direccion, string telefono, string perfil)
        {
            this.cedula = cedula;
            this.contraseña = contraseña;
            this.primerNom = primerNom;
            this.segundoNom = segundoNom;
            this.primerAp = primerAp;
            this.segundoAp = segundoAp;
            this.email = email;
            this.direccion = direccion;
            this.telefono = telefono;
            this.perfil = perfil;
        }
        #endregion

        #region Metodos


        #endregion

        #region MetodosSerializacion


        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("cedula", this.cedula, typeof(string));
            info.AddValue("contrasena", this.contraseña, typeof(string));
            info.AddValue("primerNom", this.primerNom, typeof(string));
            info.AddValue("segundoNom", this.segundoNom, typeof(string));
            info.AddValue("primerAp", this.primerAp, typeof(string));
            info.AddValue("segundoAp", this.segundoAp, typeof(string));
            info.AddValue("email", this.email, typeof(string));
            info.AddValue("direccion", this.direccion, typeof(string));
            info.AddValue("telefono", this.telefono, typeof(string));
            info.AddValue("perfil", this.perfil, typeof(string));

        }

        public Usuario(SerializationInfo info, StreamingContext context)
        {

            this.cedula = (string)info.GetValue("cedula", typeof(string));
            this.contraseña = (string)info.GetValue("contrasena", typeof(string));
            this.primerNom = (string)info.GetValue("primerNom", typeof(string));
            this.segundoNom = (string)info.GetValue("segundoNom", typeof(string));

            this.primerAp = (string)info.GetValue("primerAp", typeof(string));
            this.segundoAp = (string)info.GetValue("segundoAp", typeof(string));
            this.email = (string)info.GetValue("email", typeof(string));
            this.direccion = (string)info.GetValue("direccion", typeof(string));
            this.telefono = (string)info.GetValue("telefono", typeof(string));
            this.perfil = (string)info.GetValue("perfil", typeof(string));

        }
        #endregion
    }
}
