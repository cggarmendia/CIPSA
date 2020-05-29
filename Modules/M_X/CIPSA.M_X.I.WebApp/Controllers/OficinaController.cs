using CIPSA.Util.ConsoleApp.Class.M_X.I;
using System.Web.Http;

namespace CIPSA.M_X.I.WebApp.Controllers
{
    public class OficinaController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            return CreateOficina(superficies: 100, plantas: 2, habitciones: 3, extintores: 1, telefonos: 1).ToString();
        }
        
        private static Office CreateOficina(int superficies, int plantas, int habitciones, int extintores, int telefonos)
        {
            return new Office(extintores, telefonos, superficies, plantas, habitciones);
        }
    }
}