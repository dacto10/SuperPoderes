using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SuperServicio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICargarSuperPoderes" in both code and config file together.
    [ServiceContract]
    public interface ICargarSuperPoderes
    {
        [OperationContract]
        CargarSuperPoderesResponse updateSuperPoderes();

        [OperationContract]
        ObtenerSuperPoderesResponse getSuperPoderes(ObtenerSuperPoderesRequest request);
    }

    [DataContract]
    public class CargarSuperPoderesResponse
    {
        string message = "Super poderes actualizados de forma satisfactoria.";
        [DataMember]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }

    [DataContract]
    public class ObtenerSuperPoderesRequest
    {
        string tipo = "";
        [DataMember]
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }

    [DataContract]
    public class ObtenerSuperPoderesResponse
    {
        string message = "";
        List<string> personas;
        [DataMember]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        [DataMember]
        public List<string> Personas
        {
            get { return personas; }
            set { personas = value; }
        }
    }
}
