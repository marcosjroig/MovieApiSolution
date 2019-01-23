using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Api.Movie.Domain.Models.Validation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AtLeastOnePropertyAttribute : ValidationAttribute
    {
        // Have to override IsValid
        public override bool IsValid(object value)
        {
            //  Need to use reflection to get properties of "value"...
            var typeInfo = value.GetType();

            var propertyInfo = typeInfo.GetProperties();

            foreach (var property in propertyInfo)
            {
                if (null != property.GetValue(value, null))
                {
                    return !string.IsNullOrWhiteSpace(property.GetValue(value, null).ToString());
                }
            }

            // All properties were null.
            return false;
        }
    }
}
