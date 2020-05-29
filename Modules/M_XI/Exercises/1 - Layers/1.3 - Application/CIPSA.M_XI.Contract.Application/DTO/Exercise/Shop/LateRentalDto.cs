using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA.M_XI.Contract.Application.DTO.Exercise.Shop
{
    public class LateRentalDto
    {
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public int ClientId { get; set; }
        public string ClientNIF { get; set; }
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public string RentalDate { get; set; }
        public int LateRentalTotalDays { get; set; }
    }
}
