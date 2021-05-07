using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Sendbird.Core
{
    public static class SendbirdTypeRegistry
    {
        public static readonly IReadOnlyDictionary<string, Type> ObjectsToTypes = new ReadOnlyDictionary<string, Type>(new Dictionary<string, Type>
        {
        });

        public static Type GetConcreteType(Type potentialType, string objectValue)
        {
            if (potentialType != null && !potentialType.GetTypeInfo().IsInterface)
            {
                return potentialType;
            }

            Type concreteType = null;

            if (!string.IsNullOrEmpty(objectValue) &&
                ObjectsToTypes.TryGetValue(objectValue, out concreteType))
            {
                if (potentialType.GetTypeInfo().IsAssignableFrom(concreteType.GetTypeInfo()))
                {
                    return concreteType;
                }
            }

            return null;
        }
    }
}
