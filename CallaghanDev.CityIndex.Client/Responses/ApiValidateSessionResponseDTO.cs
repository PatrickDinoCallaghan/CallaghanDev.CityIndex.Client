using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{

    /// <summary>
    /// Response indicating whether a session is valid.
    /// </summary>
    public class ApiValidateSessionResponseDTO
    {
        /// <summary>
        /// True if the session is valid; otherwise, false.
        /// </summary>
        public bool IsAuthenticated { get; set; }
    }


}
