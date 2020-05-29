using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CIPSA.M_VI.WebApp.Controllers
{
    public class ExerciseElevenController : ApiController
    {
        private Dictionary<string, string> wordsEnabledToTranslate = new Dictionary<string, string>() {
                { "acción", "action" },
                { "edad", "age" },
                { "aire", "air" },
                { "animal", "animal" },
                { "respuesta", "answer" },
                { "manzana", "apple" },
                { "arte", "art" },
                { "bebé", "baby" },
                { "espalda", "back" },
                { "banco", "bank" },
                { "cama", "bed" },
                { "factura", "bill" },
                { "pájaro", "bird" },
                { "sangre", "blood" },
                { "barco", "boat" },
                { "cuerpo", "body" },
                { "hueso", "bone" },
                { "fondo", "bottom" },
                { "caja", "box" },
                { "niño", "boy" },
                { "hermano", "brother" },
                { "negocio", "business" },
                { "llamada", "call" }
            };

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return wordsEnabledToTranslate.Keys.Select(key => key);
        }

        // GET api/<controller>/5
        public string Get(string id)
        {
            wordsEnabledToTranslate.TryGetValue(id.ToLower(), out string wordTranslated);

            return wordTranslated ?? string.Empty;
        }
    }
}