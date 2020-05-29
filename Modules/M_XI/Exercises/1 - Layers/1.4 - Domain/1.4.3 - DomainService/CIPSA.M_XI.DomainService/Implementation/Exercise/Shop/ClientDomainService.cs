using System;
using System.Collections.Generic;
using System.Linq;
using CIPSA.M_XI.Domain.Entities.Exercise.Shop;
using CIPSA.M_XI.Domain.Extension.Exercise.Shop;
using CIPSA.M_XI.Domain.UnitOfWork.Exercise.Shop;
using CIPSA.M_XI.DomainService.Contract.Exercise.Shop;

namespace CIPSA.M_XI.DomainService.Implementation.Exercise.Shop
{
    public class ClientDomainService : DomainServiceBase<Client>, IClientDomainService
    {
        public ClientDomainService(IShopUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<string> GetClientsNIF()
        {
            return AsQueryable().Select(client => client.NIF);
        }
        
        public bool IsAdult(params object[] keyValues)
        {
            var client = GetByPKs(keyValues);
            return client.Birthday.IsAdult();
        }
    }
}