using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SuperServicio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CargarSuperPoderes" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CargarSuperPoderes.svc or CargarSuperPoderes.svc.cs at the Solution Explorer and start debugging.
    public class CargarSuperPoderes : ICargarSuperPoderes
    {
        public ObtenerSuperPoderesResponse getSuperPoderes(ObtenerSuperPoderesRequest request)
        {
            var response = new ObtenerSuperPoderesResponse();
            try
            {
                response.Message = "Listado de " + request.Tipo + " con super poderes";
                response.Personas = SuperPoderesRepository.GetSuperPoderes(request.Tipo);
                return response;
            } catch (Exception e)
            {
                response.Message = "Ha ocurrido un error: " + e.Message;
                return response;
            }
        }

        public CargarSuperPoderesResponse updateSuperPoderes()
        {
            try
            {
                SuperPoderesServicio.CargarSuperPoderes();
                return new CargarSuperPoderesResponse();
            } catch (Exception e)
            {
                CargarSuperPoderesResponse res = new CargarSuperPoderesResponse();
                res.Message = "Ha ocurrido el siguiente error: " + e.Message;
                return res;
            }
        }
    }
}
