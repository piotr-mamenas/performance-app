using System.ComponentModel;

namespace Core.Dtos
{
    public class AssetDto
    {
        public int Id { get; set; }

        [DisplayName("Asset Name")]
        public string Name { get; set; }

        [DisplayName("Asset ISIN")]
        public string Isin { get; set; }
    }
}
