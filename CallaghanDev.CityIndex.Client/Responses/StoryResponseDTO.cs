using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{

    /// <summary>
    /// Response containing detailed information for a news story.
    /// </summary>
    public class StoryResponseDTO
    {
        /// <summary>
        /// The unique identifier of the news story.
        /// </summary>
        public int StoryId { get; set; }

        /// <summary>
        /// The title of the news story.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The full content/body of the news story.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// The date and time when the story was published.
        /// </summary>
        public DateTime PublishDate { get; set; }
    }
}
