using Newtonsoft.Json;
using System.Collections;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace AB.Inventory.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static async Task<TModel> ConvertToModel<TModel>(this HttpResponseMessage message)
        {
            return JsonConvert.DeserializeObject<TModel>(await message.Content.ReadAsStringAsync(), new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }

        public static ByteArrayContent ToByteArrayContent(this object obj, string header = "application/json")
        {
            var param = JsonConvert.SerializeObject(obj);
            var buffer = Encoding.UTF8.GetBytes(param);
            var byteContent = new ByteArrayContent(buffer);
            if (!string.IsNullOrWhiteSpace(header))
                byteContent.Headers.ContentType = new MediaTypeHeaderValue(header);
            return byteContent;
        }

        public static string ToQueryString(this object obj)
        {
            var result = new List<string>();
            var props = obj.GetType().GetProperties().Where(p => p.GetValue(obj, null) != null);
            foreach (var p in props)
            {
                var value = p.GetValue(obj, null);
                var enumerable = value as ICollection;
                if (enumerable != null)
                {
                    result.AddRange(from object v in enumerable select string.Format("{0}={1}", p.Name, HttpUtility.UrlEncode(v.ToString())));
                }
                else
                {
                    result.Add(string.Format("{0}={1}", p.Name, HttpUtility.UrlEncode(value.ToString())));
                }
            }

            return string.Join("&", result.ToArray());
        }
    }
}
