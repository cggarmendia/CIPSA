using CIPSA.Util.ConsoleApp.Class.M_X.I;
using System.Web.Http;

namespace CIPSA.M_X.I.WebApp.Controllers
{
    public class CasaController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            return CreateCasa(superficies: 100, plantas: 2, habitaciones: 3, dormitorios: 2, banos: 1).ToString();
        }

        private static House CreateCasa(int superficies, int plantas, int habitaciones, int dormitorios, int banos)
        {
            return new House(dormitorios, banos, superficies, plantas, habitaciones);
        }

    }
}