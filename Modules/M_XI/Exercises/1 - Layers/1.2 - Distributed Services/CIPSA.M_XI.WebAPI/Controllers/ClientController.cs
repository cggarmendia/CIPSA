using CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop;
using CIPSA.M_XI.Contract.Application.ServiceContract.Exercise.Shop;
using System.Web.Http;

namespace CIPSA.M_XI.WebAPI.Controllers
{
    public class ClientController : ApiController
    {
        private readonly IClientApplicationService _clientApplicationService;

        public ClientController(IClientApplicationService clientApplicationService)
        {
            _clientApplicationService = clientApplicationService;
        }

        public ClientController()
        {
        }

        [HttpGet]
        public ClientDto FindClientById(int id)
        {
            return _clientApplicationService.GetByPKs(id);
        }

        [HttpGet]
        public ClientDto FindClientByNIF(string nif)
        {
            return _clientApplicationService.GetByNIF(nif);
        }

        [HttpPost]
        public int AddClient([FromBody]ClientDto dto)
        {
            _clientApplicationService.Add(dto);
            return _clientApplicationService.GetByNIF(dto.NIF).Id;
        }

        [HttpPut]
        public void UpdateClient([FromBody]ClientDto dto)
        {
            _clientApplicationService.Update(dto);
        }

        [HttpDelete]
        public void DeleteClient(int id)
        {
            _clientApplicationService.Delete(id);
        }
    }
}