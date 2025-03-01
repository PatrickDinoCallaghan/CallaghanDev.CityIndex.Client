using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{



    /// <summary>
    /// Response containing a list of spread markets.
    /// </summary>
    public class ListSpreadMarketsResponseDTO
    {
        /// <summary>
        /// A list of spread market details.
        /// </summary>
        public List<MarketDTO> Markets { get; set; }
    }


}
