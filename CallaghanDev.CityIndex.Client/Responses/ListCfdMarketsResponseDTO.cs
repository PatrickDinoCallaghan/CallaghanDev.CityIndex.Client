using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{



    /// <summary>
    /// Response containing a list of CFD markets.
    /// </summary>
    public class ListCfdMarketsResponseDTO
    {
        /// <summary>
        /// A list of CFD market details.
        /// </summary>
        public List<MarketDTO> Markets { get; set; }
    }


}
