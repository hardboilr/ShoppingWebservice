using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShoppingWebservice.Models;

// todo: check for null values!
namespace ShoppingWebservice.JsonConverters {
    public class ItemJson : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var item = value as Item;

            writer.WriteStartObject();

            writer.WritePropertyName("name");
            serializer.Serialize(writer, item.Name);

            writer.WritePropertyName("description");
            serializer.Serialize(writer, item.Description);

            writer.WritePropertyName("price");
            serializer.Serialize(writer, item.Price);

            writer.WritePropertyName("categories");
            serializer.Serialize(writer, item.Categories);

            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            JObject jsonJObject = JObject.Load(reader);

            string name = jsonJObject.GetValue("name").ToString();
            string description = jsonJObject.GetValue("description").ToString();
            float price = float.Parse(jsonJObject.GetValue("price").ToString());


            Debug.WriteLine(name);
            Debug.WriteLine(description);
            Debug.WriteLine(price);

            List<Category> categories = new List<Category>();

            // http://stackoverflow.com/questions/21002297/getting-the-name-key-of-a-jtoken-with-json-net
            foreach (JObject jObject in jsonJObject.GetValue("categories").Children<JObject>()) {
                string categoryName = jObject.GetValue("categoryName").ToString();
                string catDescription = jObject.GetValue("description").ToString();
                Category category = new Category(categoryName, catDescription);
                categories.Add(category);

                Debug.WriteLine(categoryName);
                Debug.WriteLine(catDescription);

            }
            return new Item(name, description, price, categories);
        }

        public override bool CanConvert(Type objectType) {
            return typeof(Item).IsAssignableFrom(objectType);
        }
    }
}