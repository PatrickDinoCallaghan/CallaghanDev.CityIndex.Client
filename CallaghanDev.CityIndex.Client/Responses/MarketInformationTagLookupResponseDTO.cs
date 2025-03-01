using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{


    /// <summary>
    /// Response containing market tag lookup information.
    /// </summary>
    public class MarketInformationTagLookupResponseDTO
    {
        /// <summary>
        /// A list of market tags that the user is permitted to view.
        /// </summary>
        public List<MarketTagDTO> Tags { get; set; }
    }
}
