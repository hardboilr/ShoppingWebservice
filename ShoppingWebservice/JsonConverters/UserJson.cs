using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using Newtonsoft.Json;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.JsonConverters {
    //http://blog.maskalik.com/asp-net/json-net-implement-custom-serialization/

    public class UserJson : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var user = value as User;

            writer.WriteStartObject();

            writer.WritePropertyName("id");
            serializer.Serialize(writer, user.UserId);

            writer.WritePropertyName("firstName");
            serializer.Serialize(writer, user.FirstName);

            writer.WritePropertyName("lastName");
            serializer.Serialize(writer, user.LastName);

            writer.WritePropertyName("email");
            serializer.Serialize(writer, user.Email);

            writer.WriteEndObject();
        }

        public override bool CanConvert(Type objectType) {
            return typeof(User).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}