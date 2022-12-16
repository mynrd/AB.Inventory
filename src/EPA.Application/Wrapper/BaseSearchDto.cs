using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.Inventory.Application.Wrapper
{
    public class BaseSearchDto
    {
        [JsonProperty(Order = 0)]
        public virtual Guid? SessionKey { get; set; }

        private int _index = 1;

        [JsonProperty(Order = 100)]
        public virtual List<string> Filters { get; set; } = new List<string>();

        /// <summary>
        /// Default: 1
        /// </summary>
        [JsonProperty(Order = 101)]
        public virtual int Index
        {
            get { return _index; }
            set
            {
                _index = (value < 1) ? 1 : value;
            }
        }

        /// <summary>
        /// Default: 10
        /// </summary>
        [JsonProperty(Order = 102)]
        public virtual int Limit { get; set; }

        /// <summary>
        /// asc or desc (Default: asc)
        /// </summary>
        [JsonProperty(Order = 103)]
        public virtual string Sort { get; set; } = "asc";

        [JsonProperty(Order = 104)]
        public virtual string SortBy { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public int Skip
        {
            get
            {
                return (Index - 1) * Limit;
            }
        }
    }
}
