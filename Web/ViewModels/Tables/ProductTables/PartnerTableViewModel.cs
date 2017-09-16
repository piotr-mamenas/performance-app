using System.ComponentModel;

namespace Web.ViewModels.Tables.ProductTables
{
    public class PartnerTableViewModel
    {
        public int Id { get; set; }

        [DisplayName("Partner Name")]
        public string Name { get; set; }

        [DisplayName("Partner Number")]
        public string Number { get; set; }
    }
}