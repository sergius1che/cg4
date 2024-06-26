﻿using System.Collections.Concurrent;

namespace CG4.Impl.Dapper.Poco
{
    public static class PocoHub
    {
        private static readonly ConcurrentDictionary<Type, ClassMap> _classMaps = new();

        public static ClassMap GetMap(Type entityType)
        {
            if (!_classMaps.TryGetValue(entityType, out var map))
            {
                map = ClassMap.Map(entityType);

                _classMaps[entityType] = map;
            }

            return map;
        }

        public static ClassMap GetMap<T>()
            where T : class
        {
            return GetMap(typeof(T));
        }
    }
}
