using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabbetto.Word.Web.Server
{
    public class VerificationEmailObjectTemplate
    {
        /// <summary>
        /// The title of the template to fill
        /// </summary>
        [JsonProperty("Title")]
        public string Title { get; set; }

        /// <summary>
        /// The first content of the template to fill
        /// </summary>
        [JsonProperty("Content1")]
        public string Content1 { get; set; }

        /// <summary>
        /// The second content of the template to fill
        /// </summary>
        [JsonProperty("Content2")]
        public string Content2 { get; set; }

        /// <summary>
        /// The text button of the template to fill
        /// </summary>
        [JsonProperty("ButtonText")]
        public string ButtonText { get; set; }

        /// <summary>
        /// The url linked with the button text of the template to fill
        /// </summary>
        [JsonProperty("ButtonUrl")]
        public string ButtonUrl { get; set; }
    }
}
