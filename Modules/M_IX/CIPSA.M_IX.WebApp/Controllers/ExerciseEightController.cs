using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CIPSA.M_IX.WebApp.Controllers
{
    public class ExerciseEightController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public string Concatena(string fraseOne, string fraseTwo)
        {            
            return $"{fraseOne}{fraseTwo}";
        }

        [HttpGet]
        public string BuscaYElimina(string fraseOne, string wordToSearch)
        {
            var result = string.Empty;
            if (fraseOne.Contains(wordToSearch))
                result = fraseOne.Replace(wordToSearch, "");
            return result;
        }
        
    }
}