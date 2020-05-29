namespace CIPSA.M_XI.WebUI.Models
{
    public class RentalModel
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