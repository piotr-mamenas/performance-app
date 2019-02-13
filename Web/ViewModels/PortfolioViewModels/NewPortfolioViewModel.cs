using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Web.ViewModels.PortfolioViewModels
{
    public class NewPortfolioViewModel
    {
        /// <summary>
        /// New Portfolio Name
        /// </summary>
        [DisplayName("Portfolio Name")]
        public string Name { get; set; }

        /// <summary>
        /// New Portfolio Number
        /// </summary>
        [DisplayName("Portfolio Number")]
        public string Number { get; set; }

        /// <summary>
        /// Initial Portfolio Account
        /// </summary>
        [DisplayName("Open for Account")]
        public int SelectedAccountId { get; set; }

        public IEnumerable<SelectListItem> AccountSelection { get; set; }
    }
}
