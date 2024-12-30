using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace API
{
    public static class ModelStateDictionaryExtensions
    {
        public static IDictionary<string, IEnumerable<string>> ServerError(this ModelStateDictionary modelStateDictionary, string customErrorMessage) 
        {
            var errors = new Dictionary<string, IEnumerable<string>>();
            errors.Add(string.Empty, new List<string> { customErrorMessage });
            return errors;
        }
        public static IDictionary<string, IEnumerable<string>> ConvertToErrorMessages(this ModelStateDictionary modelStateDictionary) 
        {
            var errorMessages = new Dictionary<string, IEnumerable<string>>();
            if (modelStateDictionary != null) 
            {
                return errorMessages;
            }
            foreach (var error in modelStateDictionary) 
            {
                var errorList = error.Value.Errors.Where(error => !string.IsNullOrEmpty(error.ToString())).Select(error => error.ToString());
                if (errorList.Any()) 
                {
                    errorMessages.Add(error.Key, errorList!);
                }
            }
            return errorMessages;
        }
    }
}
