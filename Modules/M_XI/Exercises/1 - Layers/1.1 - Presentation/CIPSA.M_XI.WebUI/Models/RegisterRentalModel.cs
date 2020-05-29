using System.Collections.Generic;

namespace CIPSA.M_XI.WebUI.Models
{
    public class RegisterRentalModel
    {
        public List<RentedArticleModel> Articles { get; set; }
        public List<ClientManagementModel> Clients { get; set; }
    }
}