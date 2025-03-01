using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{


    /// <summary>
    /// Represents full market information for a given market.
    /// (Expand these properties as per the complete documentation.)
    /// </summary>
    public class FullMarketInformationDTO
    {
        /// <summary>
        /// The unique market identifier.
        /// </summary>
        public int MarketId { get; set; }

        /// <summary>
        /// The market name.
        /// </summary>
        public string MarketName { get; set; }
    }

    /// <summary>
    /// Represents a trade order.
    /// </summary>
    public class ApiTradeOrderDTO
    {
        /// <summary>
        /// The unique order identifier.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// The current status of the trade order.
        /// </summary>
        public int Status { get; set; }
    }

    /// <summary>
    /// Represents a stop limit order.
    /// </summary>
    public class ApiStopLimitOrderDTO
    {
        /// <summary>
        /// The unique order identifier.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// The current status of the stop limit order.
        /// </summary>
        public int Status { get; set; }
    }

    /// <summary>
    /// Represents a single price bar (OHLC data).
    /// </summary>
    public class PriceBarDTO
    {
        /// <summary>
        /// The timestamp of the price bar.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The open price.
        /// </summary>
        public decimal Open { get; set; }

        /// <summary>
        /// The high price.
        /// </summary>
        public decimal High { get; set; }

        /// <summary>
        /// The low price.
        /// </summary>
        public decimal Low { get; set; }

        /// <summary>
        /// The close price.
        /// </summary>
        public decimal Close { get; set; }
    }

    /// <summary>
    /// Represents a single price tick.
    /// </summary>
    public class PriceTickDTO
    {
        /// <summary>
        /// The timestamp of the tick.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The bid price.
        /// </summary>
        public decimal Bid { get; set; }

        /// <summary>
        /// The ask price.
        /// </summary>
        public decimal Ask { get; set; }

        /// <summary>
        /// The mid price.
        /// </summary>
        public decimal Mid { get; set; }
    }

    /// <summary>
    /// Represents an active order.
    /// </summary>
    public class ApiActiveOrderDTO
    {
        /// <summary>
        /// The unique order identifier.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// The type of the order.
        /// </summary>
        public string OrderType { get; set; }
    }

    /// <summary>
    /// Represents market information (for CFD or spread markets).
    /// </summary>
    public class MarketDTO
    {
        /// <summary>
        /// The unique market identifier.
        /// </summary>
        public int MarketId { get; set; }

        /// <summary>
        /// The market name.
        /// </summary>
        public string MarketName { get; set; }
    }

    /// <summary>
    /// Represents a market tag.
    /// </summary>
    public class MarketTagDTO
    {
        /// <summary>
        /// The unique tag identifier.
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// The name of the tag.
        /// </summary>
        public string TagName { get; set; }
    }

    /// <summary>
    /// Represents a news headline.
    /// </summary>
    public class NewsHeadlineDTO
    {
        /// <summary>
        /// The unique identifier for the news story.
        /// </summary>
        public int StoryId { get; set; }

        /// <summary>
        /// The headline text.
        /// </summary>
        public string Headline { get; set; }
    }

    /// <summary>
    /// Represents a full news story.
    /// </summary>
    public class NewsStoryDTO
    {
        /// <summary>
        /// The unique identifier for the news story.
        /// </summary>
        public int StoryId { get; set; }

        /// <summary>
        /// The title of the news story.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The full content of the news story.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The publication date of the story.
        /// </summary>
        public DateTime PublishDate { get; set; }
    }

}
