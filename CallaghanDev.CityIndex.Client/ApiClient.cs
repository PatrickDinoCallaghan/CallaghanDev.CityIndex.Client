using System.Text;
using CallaghanDev.CityIndex.Client.Enums;
using CallaghanDev.CityIndex.Client.Requests;
using CallaghanDev.CityIndex.Client.Responses;
using Newtonsoft.Json;

namespace CallaghanDev.CityIndex.Client
{
    public class  ApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        /// <summary>
        /// Creates a new StoneXApiClient.
        /// The baseUrl should include any required path segments (e.g. "https://ciapi.cityindex.com/TradingAPI")
        /// </summary>
        public ApiClient(string baseUrl, HttpClient httpClient = null)
        {
            _baseUrl = baseUrl.TrimEnd('/');
            _httpClient = httpClient ?? new HttpClient();
        }

        #region Private Helper Methods

        private async Task<T> PostAsync<T>(string relativeUrl, object content)
        {
            var url = $"{_baseUrl}{relativeUrl}";
            var json = JsonConvert.SerializeObject(content);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (var response = await _httpClient.PostAsync(url, httpContent))
            {
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
        }

        private async Task<T> GetAsync<T>(string relativeUrl, Dictionary<string, string> queryParams = null)
        {
            var url = new StringBuilder($"{_baseUrl}{relativeUrl}");
            if (queryParams != null && queryParams.Count > 0)
            {
                url.Append("?");
                foreach (var kvp in queryParams)
                {
                    url.Append($"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}&");
                }
                // Remove the last '&'
                url.Length--;
            }

            using (var response = await _httpClient.GetAsync(url.ToString()))
            {
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
        }

        #endregion

        #region Authentication

        /// <summary>
        /// Creates a new session (log on).
        /// POST /v2/Session
        /// </summary>
        public async Task<ApiLogOnResponseDTO> LogOnAsync(ApiLogOnRequestDTO request)
        {
            return await PostAsync<ApiLogOnResponseDTO>("/v2/Session", request);
        }

        /// <summary>
        /// Validates a session.
        /// POST /v2/Session/validate
        /// </summary>
        public async Task<ApiValidateSessionResponseDTO> ValidateSessionAsync(ApiValidateSessionRequestDTO request)
        {
            return await PostAsync<ApiValidateSessionResponseDTO>("/v2/Session/validate", request);
        }

        #endregion

        #region Market

        /// <summary>
        /// Returns a list of markets that meet the search criteria.
        /// GET /v2/market/fullSearchWithTags
        /// </summary>
        public async Task<FullMarketInformationSearchWithTagsResponseDTO> GetFullSearchWithTagsAsync(
            string query = "",
            int? tagId = null,
            bool searchByMarketCode = true,
            bool searchByMarketName = true,
            bool spreadProductType = true,
            bool cfdProductType = true,
            bool binaryProductType = true,
            bool includeOptions = true,
            int? tradingAccountId = null,
            int maxResults = 50,
            bool useMobileShortName = false)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "Query", query },
                { "TagId", (tagId ?? 0).ToString() },
                { "SearchByMarketCode", searchByMarketCode.ToString().ToUpper() },
                { "SearchByMarketName", searchByMarketName.ToString().ToUpper() },
                { "SpreadProductType", spreadProductType.ToString().ToUpper() },
                { "CfdProductType", cfdProductType.ToString().ToUpper() },
                { "BinaryProductType", binaryProductType.ToString().ToUpper() },
                { "IncludeOptions", includeOptions.ToString().ToUpper() },
                { "MaxResults", maxResults.ToString() },
                { "UseMobileShortName", useMobileShortName.ToString().ToLower() }
            };

            if (tradingAccountId.HasValue)
                queryParams.Add("TradingAccountId", tradingAccountId.Value.ToString());

            return await GetAsync<FullMarketInformationSearchWithTagsResponseDTO>("/v2/market/fullSearchWithTags", queryParams);
        }

        /// <summary>
        /// Gets all of the tags the user is allowed to see.
        /// GET /v2/market/tagLookup?clientAccountId={clientAccountId}
        /// </summary>
        public async Task<MarketInformationTagLookupResponseDTO> TagLookupAsync(int clientAccountId)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "clientAccountId", clientAccountId.ToString() }
            };
            return await GetAsync<MarketInformationTagLookupResponseDTO>("/v2/market/tagLookup", queryParams);
        }

        /// <summary>
        /// Retrieves market report headlines.
        /// GET /news/marketreportheadlines
        /// </summary>
        public async Task<NewsHeadlinesResponseDTO> GetMarketReportHeadlinesAsync(int marketID, int cultureID, int maxResults = 25)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "marketID", marketID.ToString() },
                { "cultureId", cultureID.ToString() },
                { "maxResults", maxResults.ToString() }
            };
            return await GetAsync<NewsHeadlinesResponseDTO>("/news/marketreportheadlines", queryParams);
        }

        /// <summary>
        /// Retrieves market reports.
        /// GET /news/marketreports
        /// </summary>
        public async Task<NewsResponseDTO> GetMarketReportsAsync(int marketID, int cultureID, int maxResults = 25)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "marketID", marketID.ToString() },
                { "cultureId", cultureID.ToString() },
                { "maxResults", maxResults.ToString() }
            };
            return await GetAsync<NewsResponseDTO>("/news/marketreports", queryParams);
        }

        #endregion

        #region News

        /// <summary>
        /// Retrieves a list of current news stories for the specified region.
        /// GET /news/news
        /// </summary>
        public async Task<NewsResponseDTO> GetNewsAsync(string region, int cultureID, int maxResults = 25)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "region", region },
                { "cultureId", cultureID.ToString() },
                { "maxResults", maxResults.ToString() }
            };
            return await GetAsync<NewsResponseDTO>("/news/news", queryParams);
        }

        /// <summary>
        /// Retrieves a list of current news headlines for the specified region.
        /// GET /news/newsheadlines
        /// </summary>
        public async Task<NewsHeadlinesResponseDTO> GetNewsHeadlinesAsync(string region, int cultureID, int maxResults = 25)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "region", region },
                { "cultureId", cultureID.ToString() },
                { "maxResults", maxResults.ToString() }
            };
            return await GetAsync<NewsHeadlinesResponseDTO>("/news/newsheadlines", queryParams);
        }

        /// <summary>
        /// Retrieves the detail for a specific news story.
        /// GET /news/story
        /// </summary>
        public async Task<StoryResponseDTO> GetStoryAsync(int storyID)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "storyID", storyID.ToString() }
            };
            return await GetAsync<StoryResponseDTO>("/news/story", queryParams);
        }

        /// <summary>
        /// Searches news for the specified market by headline and/or body.
        /// GET /news/searchmarketreports
        /// </summary>
        public async Task<NewsResponseDTO> SearchMarketReportsAsync(int marketID, int cultureID, int maxResults, bool searchByHeadline, bool searchByBody, string query)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "marketID", marketID.ToString() },
                { "cultureId", cultureID.ToString() },
                { "maxResults", maxResults.ToString() },
                { "searchByHeadline", searchByHeadline.ToString().ToLower() },
                { "searchByBody", searchByBody.ToString().ToLower() },
                { "query", query }
            };
            return await GetAsync<NewsResponseDTO>("/news/searchmarketreports", queryParams);
        }

        /// <summary>
        /// Searches news within a specific region by headline and/or body.
        /// GET /news/searchnews
        /// </summary>
        public async Task<NewsResponseDTO> SearchNewsAsync(string region, int cultureID, int maxResults, bool searchByHeadline, bool searchByBody, string query)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "region", region },
                { "cultureId", cultureID.ToString() },
                { "maxResults", maxResults.ToString() },
                { "searchByHeadline", searchByHeadline.ToString().ToLower() },
                { "searchByBody", searchByBody.ToString().ToLower() },
                { "query", query }
            };
            return await GetAsync<NewsResponseDTO>("/news/searchnews", queryParams);
        }

        #endregion

        #region Spread and CFD Markets

        /// <summary>
        /// Returns a list of Spread Betting markets filtered by market name and/or code.
        /// GET /spread/markets
        /// </summary>
        public async Task<ListSpreadMarketsResponseDTO> ListSpreadMarketsAsync(string searchByMarketName, string searchByMarketCode, int clientAccountId, int maxResults = 20, bool useMobileShortName = false, bool includeOptions = true, int? tradingAccountId = null)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "marketname", searchByMarketName },
                { "marketcode", searchByMarketCode },
                { "ClientAccountId", clientAccountId.ToString() },
                { "maxresults", maxResults.ToString() },
                { "usemobileshortname", useMobileShortName.ToString().ToLower() },
                { "includeOptions", includeOptions.ToString().ToLower() }
            };

            if (tradingAccountId.HasValue)
                queryParams.Add("TradingAccountId", tradingAccountId.Value.ToString());

            return await GetAsync<ListSpreadMarketsResponseDTO>("/spread/markets", queryParams);
        }

        /// <summary>
        /// Gets historic price ticks for the specified market.
        /// GET /{MarketId}/tickhistorybetween
        /// </summary>
        public async Task<GetPriceTickResponseDTO> GetPriceTicksBetweenDatesAsync(string marketId, int? maxResults, long fromTimestampUTC, long toTimestampUTC, string priceType = "MID")
        {
            var queryParams = new Dictionary<string, string>
            {
                { "fromTimeStampUTC", fromTimestampUTC.ToString() },
                { "toTimestampUTC", toTimestampUTC.ToString() },
                { "priceType", priceType }
            };

            if (maxResults.HasValue)
                queryParams.Add("maxResults", maxResults.Value.ToString());

            var relativeUrl = $"/{marketId}/tickhistorybetween";
            return await GetAsync<GetPriceTickResponseDTO>(relativeUrl, queryParams);
        }

        /// <summary>
        /// Returns a list of CFD markets filtered by market name and/or code.
        /// GET /cfd/markets
        /// </summary>
        public async Task<ListCfdMarketsResponseDTO> ListCfdMarketsAsync(string marketName, string marketCode, int clientAccountId, int maxResults = 20, bool useMobileShortName = false, bool includeOptions = false, int? tradingAccountId = null)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "marketname", marketName },
                { "marketcode", marketCode },
                { "ClientAccountId", clientAccountId.ToString() },
                { "maxresults", maxResults.ToString() },
                { "usemobileshortname", useMobileShortName.ToString().ToLower() },
                { "includeOptions", includeOptions.ToString().ToLower() }
            };

            if (tradingAccountId.HasValue)
                queryParams.Add("tradingAccountId", tradingAccountId.Value.ToString());

            return await GetAsync<ListCfdMarketsResponseDTO>("/cfd/markets", queryParams);
        }


        public async Task<GetPriceTickResponseDTO> GetPriceTicksBetweenDatesAsync(string marketId, DateTime fromUtc, DateTime toUtc, CIPriceType priceType)
        {
            // Convert the provided UTC DateTimes to Unix time (in seconds)
            long fromTimestampUTC = ((DateTimeOffset)fromUtc).ToUnixTimeSeconds();
            long toTimestampUTC = ((DateTimeOffset)toUtc).ToUnixTimeSeconds();

            // Always request the maximum number of ticks (4000)
            int maxResults = 4000;

            // Build query parameters
            var queryParams = new Dictionary<string, string>
            {
                { "fromTimeStampUTC", fromTimestampUTC.ToString() },
                { "toTimestampUTC", toTimestampUTC.ToString() },
                { "priceType", priceType.ToString() },
                { "maxResults", maxResults.ToString() }
            };

            // Build the relative URL using the marketId
            string relativeUrl = $"/{marketId}/tickhistorybetween";

            // Assume GetAsync<T> is a helper method that performs the HTTP GET and deserializes the JSON response.
            return await GetAsync<GetPriceTickResponseDTO>(relativeUrl, queryParams);
        }


        /// <summary>
        /// Gets historic price bars for the specified market.
        /// GET /{MarketId}/barhistorybetween
        /// </summary>
        public async Task<GetPriceBarResponseDTO> GetPriceBarsBetweenDatesAsync(string marketId, string interval, int span, long fromTimestampUTC, long toTimestampUTC, int? maxResults, string priceType = "MID")
        {
            var queryParams = new Dictionary<string, string>
            {
                { "interval", interval },
                { "span", span.ToString() },
                { "fromTimestampUTC", fromTimestampUTC.ToString() },
                { "toTimestampUTC", toTimestampUTC.ToString() },
                { "priceType", priceType }
            };

            if (maxResults.HasValue)
                queryParams.Add("maxResults", maxResults.Value.ToString());

            var relativeUrl = $"/{marketId}/barhistorybetween";
            return await GetAsync<GetPriceBarResponseDTO>(relativeUrl, queryParams);
        }

        #endregion

        #region Orders and Trades

        /// <summary>
        /// Queries for an order by a specific order Id.
        /// GET /{OrderId}
        /// </summary>
        public async Task<GetOrderResponseDTO> GetOrderAsync(int orderId)
        {
            var relativeUrl = $"/{orderId}";
            return await GetAsync<GetOrderResponseDTO>(relativeUrl);
        }

        /// <summary>
        /// Cancels the specified order.
        /// POST /order/cancel
        /// </summary>
        public async Task<ApiTradeOrderResponseDTO> CancelOrderAsync(CancelOrderRequestDTO cancelOrder)
        {
            return await PostAsync<ApiTradeOrderResponseDTO>("/order/cancel", cancelOrder);
        }

        /// <summary>
        /// Places a new resting entry order.
        /// POST /order/newstoplimitorder
        /// </summary>
        public async Task<ApiTradeOrderResponseDTO> PlaceOrderAsync(NewStopLimitOrderRequestDTO order)
        {
            return await PostAsync<ApiTradeOrderResponseDTO>("/order/newstoplimitorder", order);
        }

        /// <summary>
        /// Queries for a trade / open position by order ID.
        /// GET /{OrderId}/openposition
        /// </summary>
        public async Task<GetOpenPositionResponseDTO> GetOpenPositionAsync(int orderId)
        {
            var relativeUrl = $"/{orderId}/openposition";
            return await GetAsync<GetOpenPositionResponseDTO>(relativeUrl);
        }

        /// <summary>
        /// Queries for a specified trading account's open positions.
        /// GET /openpositions?TradingAccountId={TradingAccountId}
        /// </summary>
        public async Task<ListOpenPositionsResponseDTO> ListOpenPositionsAsync(int tradingAccountId)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "TradingAccountId", tradingAccountId.ToString() }
            };
            return await GetAsync<ListOpenPositionsResponseDTO>("/openpositions", queryParams);
        }

        /// <summary>
        /// Queries the stop/limit order history for a specified trading account.
        /// GET /stoplimitorderhistory
        /// </summary>
        public async Task<ListStopLimitOrderHistoryResponseDTO> ListStopLimitOrderHistoryAsync(int tradingAccountId, int? maxResults = null, long? from = null)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "TradingAccountId", tradingAccountId.ToString() }
            };

            if (maxResults.HasValue)
                queryParams.Add("maxResults", maxResults.Value.ToString());
            if (from.HasValue)
                queryParams.Add("from", from.Value.ToString());

            return await GetAsync<ListStopLimitOrderHistoryResponseDTO>("/stoplimitorderhistory", queryParams);
        }

        /// <summary>
        /// Queries for an active stop limit order by order ID.
        /// GET /{OrderId}/activestoplimitorder
        /// </summary>
        public async Task<GetActiveStopLimitOrderResponseDTO> GetActiveStopLimitOrderAsync(int orderId)
        {
            var relativeUrl = $"/{orderId}/activestoplimitorder";
            return await GetAsync<GetActiveStopLimitOrderResponseDTO>(relativeUrl);
        }

        /// <summary>
        /// Queries for a trading account's active stop/limit orders.
        /// GET /activestoplimitorders?TradingAccountId={TradingAccountId}
        /// </summary>
        public async Task<ListActiveStopLimitOrderResponseDTO> ListActiveStopLimitOrdersAsync(int tradingAccountId)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "TradingAccountId", tradingAccountId.ToString() }
            };
            return await GetAsync<ListActiveStopLimitOrderResponseDTO>("/activestoplimitorders", queryParams);
        }

        /// <summary>
        /// Queries the trade history for a specified trading account.
        /// GET /tradehistory?TradingAccountId={TradingAccountId}&maxResults={maxResults}&from={from}
        /// </summary>
        public async Task<ListTradeHistoryResponseDTO> ListTradeHistoryAsync(int tradingAccountId, int? maxResults = null, long? from = null)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "TradingAccountId", tradingAccountId.ToString() }
            };

            if (maxResults.HasValue)
                queryParams.Add("maxResults", maxResults.Value.ToString());
            if (from.HasValue)
                queryParams.Add("from", from.Value.ToString());

            return await GetAsync<ListTradeHistoryResponseDTO>("/tradehistory", queryParams);
        }

        /// <summary>
        /// Places a new trade order.
        /// POST /order/newtradeorder
        /// </summary>
        public async Task<ApiTradeOrderResponseDTO> PlaceTradeAsync(NewTradeOrderRequestDTO trade)
        {
            return await PostAsync<ApiTradeOrderResponseDTO>("/order/newtradeorder", trade);
        }

        /// <summary>
        /// Updates a resting entry order.
        /// POST /order/updatestoplimitorder
        /// </summary>
        public async Task<ApiTradeOrderResponseDTO> UpdateOrderAsync(UpdateStopLimitOrderRequestDTO order)
        {
            return await PostAsync<ApiTradeOrderResponseDTO>("/order/updatestoplimitorder", order);
        }

        /// <summary>
        /// Updates an existing trade (e.g. add a stop loss).
        /// POST /order/updatetradeorder
        /// </summary>
        public async Task<ApiTradeOrderResponseDTO> UpdateTradeAsync(UpdateTradeOrderRequestDTO update)
        {
            return await PostAsync<ApiTradeOrderResponseDTO>("/order/updatetradeorder", update);
        }

        /// <summary>
        /// Queries for all active orders for the current (or specified) trading account.
        /// POST /activeorders
        /// </summary>
        public async Task<ListActiveOrdersResponseDTO> ListActiveOrdersAsync(ListActiveOrdersRequestDTO requestDTO)
        {
            return await PostAsync<ListActiveOrdersResponseDTO>("/activeorders", requestDTO);
        }

        #endregion
    }
}
