namespace KentWebForms.Infrastructure.Utils
{
    using System.Collections.Generic;
    using System.Reflection;

    public static class ConverterUtils
    {
        public static Dictionary<string, string> ModelToDictionary<TModel>(TModel model)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            PropertyInfo[] properties = model.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                string propertyName = property.Name;
                string propertyValue = property.GetValue(model).ToString();
                dictionary.Add(propertyName, propertyValue);
            }

            return dictionary;
        }
    }
}
