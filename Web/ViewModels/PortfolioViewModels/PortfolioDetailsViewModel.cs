using System.ComponentModel;

namespace Web.ViewModels.PortfolioViewModels
{
    public class PortfolioDetailsViewModel
    {
        [DisplayName("Portfolio Id")]
        public int? PortfolioId { get; set; }

        [DisplayName("Portfolio Name")]
        public string PortfolioName { get; set; }

        [DisplayName("Portfolio Number")]
        public string PortfolioNumber { get; set; }

        [DisplayName("Account Number")]
        public string PortfolioAccountNumber { get; set; }

        [DisplayName("Owner")]
        public string PortfolioAccountOwner { get; set; }

        public int AccountId { get; set; }

        public PortfolioAssetPositionViewModel Positions { get; set; }
    }
}
