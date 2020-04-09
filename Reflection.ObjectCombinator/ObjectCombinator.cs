using System;
using System.Collections.Generic;
using System.Linq;

namespace Reflection.ObjectCombinator
{
    public class ObjectCombinator<T> where T: class
    {
        public T MergeObjects(T original, T current)
        {
            var propertiesNames = GetPropertiesNames(original);
            return MergeObjects(original, current, propertiesNames);
        }

        public T MergeObjects(T original, T current, List<string> propertiesNames)
        {
            propertiesNames.ForEach(propName =>
            {
                var propCurrent = GetPropertyValue(current, propName);
                var propOriginal = GetPropertyValue(original, propName);

                if (propCurrent != null && propOriginal != null && propCurrent.GetType().Name == "String" && string.IsNullOrEmpty((string)propCurrent))
                    SetPropertyValue(ref current, propName, propOriginal);

                if (propCurrent == null && propOriginal != null)
                    SetPropertyValue(ref current, propName, propOriginal);
            });

            return current;
        }

        private List<string> GetPropertiesNames(T obj)
        {
            Type type = obj.GetType();
            return type.GetProperties().Select(x => x.Name).ToList();
        }

        private object GetPropertyValue(T obj, string propertyName)
        {
            Type type = obj.GetType();
            return type.GetProperty(propertyName).GetValue(obj);
        }

        private void SetPropertyValue(ref T current, string propName, object originalValue)
        {
            Type type = current.GetType();
            type.GetProperty(propName).SetValue(current, originalValue);
        }
    }
}
