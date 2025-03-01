﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{

    /// <summary>
    /// Represents a trade order.
    /// Derived from ApiTradeOrderDTO > ApiOrderDTO as defined in the StoneX API documentation.
    /// </summary>
    public class ApiTradeOrderResponseDTO
    {
        /// <summary>
        /// The unique order identifier generated by the platform.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// The status code of the order (e.g. 1 for Pending, 2 for Accepted, etc.).
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// The list of constituent trades for Trading Advisor managed positions (if applicable).
        /// </summary>
        public List<ApiManagedTradeDTO> ManagedTrades { get; set; }

        /// <summary>
        /// The date and time that the order was created in UNIX time format.
        /// This can be the time an active order was created (which then becomes an open position after a fill)
        /// or the time a market order was executed.
        /// The format is wcf-date.
        /// </summary>
        public string CreatedDateTimeUTC { get; set; }

        /// <summary>
        /// The spread cost as a decimal value (nullable).
        /// </summary>
        public decimal? SpreadCost { get; set; }

        /// <summary>
        /// The commission as a decimal value (nullable).
        /// </summary>
        public decimal? Commision { get; set; }
    }

    /// <summary>
    /// A constituent order of a Trading Advisor managed position.
    /// </summary>
    public class ApiManagedTradeDTO
    {
        /// <summary>
        /// The unique identifier for the order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// The order size or amount.
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// The unique identifier for the managed trading account that the order is being placed on.
        /// </summary>
        public int TradingAccountId { get; set; }

        /// <summary>
        /// The code of the managed trading account that the order is being placed on.
        /// </summary>
        public string TradingAccountCode { get; set; }

        /// <summary>
        /// The name of the managed trading account that the order is being placed on.
        /// </summary>
        public string TradingAccountName { get; set; }

        /// <summary>
        /// Represents the date and time when the order was last changed, in WCF date format.
        /// Note: Does not include things such as the current market price.
        /// </summary>
        public string LastChangedDateTimeUTC { get; set; }
    }
}
