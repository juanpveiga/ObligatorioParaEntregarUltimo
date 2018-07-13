using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class CRol : ISerializable
    {
        #region Atributos
        private static CRol instancia;
        private List<Rol> roles = new List<Rol>();
        #endregion

        #region Propiedades
        public static CRol Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new CRol();
                }
                return instancia;
            }
        }
        #endregion

        #region Costructor Singleton
        private CRol()
        {

        }
        #endregion

        #region Metodos
        public Rol buscarRol(string nomRol)
        {
            Rol r = null;
            int i = 0;

            while(i < roles.Count && r == null)
            {
                if(roles[i].NomRol == nomRol)
                {
                    r = roles[i];
                }
                i++;
            }
            return r;
        }

        public bool altaRol(string nomRol, double valorHora)
        {
            bool alta = false;
            int cantRoles = this.roles.Count;

            if(buscarRol(nomRol) == null && nomRol != "" && valorHora >= 0)
            {
                roles.Add(new Rol(nomRol, valorHora));
            }
            if(cantRoles < this.roles.Count)
            {
                alta = true;
            }

            return alta;
        }
        #endregion

        #region MetodosSerializacion
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("roles", this.roles, typeof(List<Rol>));


        }
        public CRol(SerializationInfo info, StreamingContext context)
        {


            this.roles = (List<Rol>)info.GetValue("roles", typeof(List<Rol>));
            CRol.instancia = this;
        }
        #endregion
    }
}
