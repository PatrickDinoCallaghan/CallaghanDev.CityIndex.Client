using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Request to validate the credentials for a session.
    /// </summary>
    public class ApiValidateSessionRequestDTO
    {
        /// <summary>
        /// Client account identifier (nullable).
        /// </summary>
        public int? ClientAccountId { get; set; }

        /// <summary>
        /// The username to validate (nullable).
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The session ID to validate with the username (nullable).
        /// </summary>
        public string Session { get; set; }

        /// <summary>
        /// Trading account identifier (nullable).
        /// </summary>
        public int? TradingAccountId { get; set; }

        /// <summary>
        /// Contract identifier (nullable).
        /// </summary>
        public int? ContractId { get; set; }
    }
}
