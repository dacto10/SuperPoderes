using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperServicio
{
    public class SuperPoderesServicio
    {
        public static void CargarSuperPoderes()
        {
            var nombres = SuperPoderesRepository.GetSuperPoderes("REGISTRADOS");
            var villanos = new List<string>();
            var heroes = new List<string>();

            foreach (var nombre in nombres)
            {
                if (EsVillano(nombre)) villanos.Add(nombre);
                else heroes.Add(nombre);
            }

            SuperPoderesRepository.SetSuperPoderes(heroes, "HEROES");
            SuperPoderesRepository.SetSuperPoderes(villanos, "VILLANOS");
        }

        public static List<string> ObtenerSuperPoderes(string tipo)
        {
            return SuperPoderesRepository.GetSuperPoderes(tipo.ToUpper());
        }

        public static bool EsVillano(string nombre)
        {
            return nombre.Contains("D") || nombre.Contains("d");
        }
    }
}