using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Response containing a list of active orders.
    /// </summary>
    public class ListActiveOrdersResponseDTO
    {
        /// <summary>
        /// A list of active orders.
        /// </summary>
        public List<ApiActiveOrderDTO> Orders { get; set; }
    }
}
