using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{

    /// <summary>
    /// Response containing news headlines.
    /// </summary>
    public class NewsHeadlinesResponseDTO
    {
        /// <summary>
        /// A list of news headlines.
        /// </summary>
        public List<NewsHeadlineDTO> Headlines { get; set; }
    }

}
