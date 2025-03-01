using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Response containing full news stories.
    /// </summary>
    public class NewsResponseDTO
    {
        /// <summary>
        /// A list of news stories.
        /// </summary>
        public List<NewsStoryDTO> NewsStories { get; set; }
    }
}
