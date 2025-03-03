using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// The response from a price bar history GET request.
    /// Contains both an array of finalized price bars and a partial (not finalized) bar for the current period.
    /// </summary>
    public class GetPriceBarResponseDTO
    {
        /// <summary>
        /// An array of finalized price bars, sorted in ascending order based on PriceBar.BarDate.
        /// </summary>
        public PriceBarDTO[] PriceBars { get; set; }

        /// <summary>
        /// The (non-finalized) price bar data for the current period (i.e., the period that has not yet completed).
        /// </summary>
        public PriceBarDTO PartialPriceBar { get; set; }
    }

   
}
