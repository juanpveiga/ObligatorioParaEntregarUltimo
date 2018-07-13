using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace obligTallerObjDominio
{
    [Serializable]
    public class CUsuario : ISerializable
    {
        #region Atributos
        private static CUsuario instancia;
        private List<Usuario> usuarios = new List<Usuario>();
        #endregion

        #region Propiedades
        public static CUsuario Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new CUsuario();
                }
                return instancia;
            }
           
        }
        #endregion

        #region Constructor Singleton
        private CUsuario()
        {

        }
        #endregion

        #region Metodos
        public Usuario buscarUsuario(string cedula)
        {
            int i = 0;
            Usuario u = null;

            while (i < usuarios.Count && u == null)
            {
                if (usuarios[i].Cedula == cedula)
                {
                    u = usuarios[i];
                }
                i++;
            }
            return u;
        }

        public bool altaUsuario(string cedula, string contraseña, string primerNom, string segundoNom,
            string primerAp, string segundoAp, string email, string direccion, string telefono, string perfil)
        {
            bool agregado = false;
            int cantUsuarios = this.usuarios.Count;
            if (buscarUsuario(cedula) == null && validarContraseña(contraseña) && primerNom != "" && primerAp != "" && perfil != "")
            {
                usuarios.Add(new Usuario(cedula, contraseña, primerNom, segundoNom, primerAp, segundoAp,
                    email, direccion, telefono, perfil));
            }

            if (cantUsuarios < this.usuarios.Count)
            {
                agregado = true;
            }
            return agregado;
        }

        public bool validarContraseña(string contraseña)
        {
            bool valido = true;

            if (contraseña != String.Empty)
            {
                bool contNum = false;
                bool contString = false;
                int totalCaracteres = 0;
                foreach (char item in contraseña)
                {
                    if (Char.IsNumber(item))
                    {
                        contNum = true;
                        totalCaracteres++;
                    }
                    else if (Char.IsLetter(item))
                    {
                        contString = true;
                        totalCaracteres++;
                    }
                }
                if (contString || contNum && totalCaracteres == contraseña.Count<char>() && contraseña.Count<char>() >= 8)
                {
                    valido = true;
                }
            }
            return valido;
        }

        public string buscarPerfilUsuario(string nombre, string password)
        {
            string perfil = "";
            bool bandera = false;
            int i = 0;
            while (i < usuarios.Count && !bandera)
            {
                if (usuarios[i].Cedula == nombre && usuarios[i].Contraseña == password)
                {
                    bandera = true;
                    perfil = usuarios[i].Perfil;
                }
                i++;
            }
            return perfil;
        }
        #endregion

        #region metodos Serializacion
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {

            info.AddValue("usuarios", this.usuarios, typeof(List<Lugar>));


        }
        public CUsuario(SerializationInfo info, StreamingContext context)
        {


            this.usuarios = (List<Usuario>)info.GetValue("usuarios", typeof(List<Usuario>));
            CUsuario.instancia = this;

        }
        #endregion
    }
}
