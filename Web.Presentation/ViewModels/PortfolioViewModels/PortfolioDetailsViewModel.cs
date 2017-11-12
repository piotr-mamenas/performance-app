using Service.Dtos.Portfolio;

namespace Web.Presentation.ViewModels.PortfolioViewModels
{
    public class PortfolioDetailsViewModel
    {
        public int? PortfolioId { get; set; }

        public string PortfolioName { get; set; }

        public string PortfolioNumber { get; set; }

        public string PortfolioAccountNumber { get; set; }

        public string PortfolioAccountOwner { get; set; }

        public PortfolioAssetPositionDto Positions { get; set; }
    }
}
