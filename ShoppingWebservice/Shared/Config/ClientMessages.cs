
namespace ShoppingWebservice.Shared.Config {

    public class ClientMessages {

        public static string ExistMsg(string domain) {
            return domain + " already exist.";
        }

        public static string SuccessCreate(string identifier) {
            return "Successfully created new " + identifier;
        }

        public static string SuccessUpdate(string identifier) {
            return "Successfully updated " + identifier;
        }

        public static string SuccessDelete(string identifier) {
            return "Successfully deleted " + identifier;
        }

        public static string ContentMsg(string domain) {
            return "Successfully retrieved " + domain + ".";
        }

        public static string ContentMsg(string domain, string name) {
            return "Successfully retrieved " + domain + " with id: " + name + ".";
        }

        public static string NotFoundMsg(string domain) {
            return "No " + domain + " found in database.";
        }

        public static string NotFoundMsg(string domain, string id) {
            return "No " + domain + " with id: " + id + " found.";
        }
    }
}