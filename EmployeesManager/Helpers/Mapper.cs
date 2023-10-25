using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Helpers
{
    public class Mapper
    {
        public void CustomMapping(Action<Action> mappingFunction)
        {
            mappingFunction?.Invoke(null);
        }

        public TDestination MapObject<TSource, TDestination>(TSource source) where TDestination : class, new()
        {
            var sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public 
                | BindingFlags.Static
                | BindingFlags.Instance);

            var destinationProperties = typeof(TDestination).GetProperties(BindingFlags.Public 
                | BindingFlags.Static
                | BindingFlags.Instance);

            //var enums = destinationProperties.Where(a => a.PropertyType.BaseType == typeof(System.Enum));

            //var enumValue = GetEnumValue<System.Enum>(enums.First().GetValue(source).ToString() , enums.First().PropertyType);

            var matchingProperties = GetMatchingProperties(source, sourceProperties, destinationProperties);

            var mappedObject = new TDestination();

            foreach (var matchingProperty in matchingProperties)
            {
                destinationProperties
                    .FirstOrDefault(a => a.Name == matchingProperty.Key)
                    .SetValue(mappedObject, matchingProperty.Value);
            }

            return mappedObject;
        }

        private Dictionary<string, object> GetMatchingProperties<TSource>(TSource sourceObject, 
            IEnumerable<PropertyInfo> sourceProperties, 
            IEnumerable<PropertyInfo> destinationProperties)
        {
            var matchingProperties = new Dictionary<string, object>();

            foreach (var destinationProperty in destinationProperties)
            {
                foreach (var sourceProperty in sourceProperties)
                {
                    if (destinationProperty.Name == sourceProperty.Name)
                    {
                        matchingProperties.Add(destinationProperty?.Name, sourceProperty?.GetValue(sourceObject));
                        break;
                    }
                }
            }

            return matchingProperties;
        }

        private object GetEnumValue<T>(string enumProperty, Type enumType) where T : System.Enum
        {
            return Enum.Parse(enumType, enumProperty);
        }
    }
}
