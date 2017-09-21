using System.Collections.Generic;

namespace Service.Dtos
{
    public class InstitutionDto
    {
        /// <summary>
        /// BaseBank Properties
        /// </summary>
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PartnerDto> Partners { get; set; }

        /// <summary>
        /// Bank Dto Properties Extension
        /// </summary>
        public string Bic { get; set; }
    }
}
