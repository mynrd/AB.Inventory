using Newtonsoft.Json;

namespace AB.Inventory.Application.Wrapper
{
    public class PagingModel
    {
        /// <summary>
        /// Row Counts to show
        /// </summary>
        [JsonProperty(Order = -1)]
        public int Limit { get; set; }

        /// <summary>
        /// Page Index
        /// </summary>
        [JsonProperty(Order = -2)]
        public int Index { get; set; } = 1;

        [System.Text.Json.Serialization.JsonIgnore]
        public int Skip
        {
            get
            {
                return (Index - 1) * Limit;
            }
        }

        public bool CanPage()
        {
            return this.Limit > 0;
        }
    }
}