using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starlight
{
    public static class TypeExtensions
    {
        // https://stackoverflow.com/a/37184228/14261424
        public static bool IsDerivedFromGenericParent(this Type type, Type parentType) {
            if (!parentType.IsGenericType) {
                throw new ArgumentException("type must be generic", "parentType");
            }
            if (type == null || type == typeof(object)) {
                return false;
            }
            if (type.IsGenericType && type.GetGenericTypeDefinition() == parentType) {
                return true;
            }
            return type.BaseType.IsDerivedFromGenericParent(parentType) || type.GetInterfaces().Any(t => t.IsDerivedFromGenericParent(parentType));
        }
    }
}
