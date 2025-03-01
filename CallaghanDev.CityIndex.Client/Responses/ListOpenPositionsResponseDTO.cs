using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Response containing a list of open positions.
    /// </summary>
    public class ListOpenPositionsResponseDTO
    {
        /// <summary>
        /// A list of open positions.
        /// </summary>
        public List<GetOpenPositionResponseDTO> Positions { get; set; }
    }
}
