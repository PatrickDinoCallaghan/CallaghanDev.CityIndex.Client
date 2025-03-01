using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{


    /// <summary>
    /// Response for a full market information search with tags.
    /// </summary>
    public class FullMarketInformationSearchWithTagsResponseDTO
    {
        /// <summary>
        /// A list of markets matching the search criteria.
        /// </summary>
        public List<FullMarketInformationDTO> Markets { get; set; }
    }



}
