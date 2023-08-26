using System;
using System.Collections.Generic;

namespace Infrastructure.ServiceLocator
{
    public static class Locator
    {
        private static readonly Dictionary<Type, object> Services = new Dictionary<Type, object>();
        public static event Action<Type> onComponentRegistered;

        public static T Resolve<T>()
        {
            return Resolve<T>(typeof(T));
        }

        public static bool Contains<T>()
        {
            var type = typeof(T);
            return Services.ContainsKey(type);
        }

        public static T ResolveOrCreate<T>() where T : new()
        {
            return TryResolve<T>(out var result)
                ? (T)result
                : CreateInstance<T>();
        }

        public static T ResolveAndRemove<T>()
        {
            var type = typeof(T);
            var service = Resolve<T>(type);
            TryRemove(type);

            return service;
        }

        public static void Register<TService>(TService service)
        {
            Register(typeof(TService), service);
        }

        public static void Register<TType, TService>(TService service)
        {
            Register(typeof(TType), service);
        }

        public static void Register<TService>(Type type, TService service)
        {
            if (Services.ContainsKey(type))
            {
                if (Services[type] != null) return;

                Services[type] = service;
                return;
            }

            AddService(type, service);
        }

        public static void RegisterOrReplace<T>(T service)
        {
            var needType = typeof(T);
            TryRemove(needType);

            AddService(needType, service);
        }

        public static void Remove<T>(T component)
        {
            var needType = typeof(T);

            TryRemove(needType);
        }

        public static void TryRemove<T>()
        {
            var type = typeof(T);
            TryRemove(type);
        }

        public static void TryRemove(Type value)
        {
            if (Services.ContainsKey(value))
                Services.Remove(value);
        }

        private static T Resolve<T>(Type type)
        {
            if (Services.TryGetValue(type, out var result))
            {
                return (T)result;
            }

            return default;
        }

        public static bool TryResolve<T>(out T value)
        {
            if (Services.TryGetValue(typeof(T), out var valueObj))
            {
                value = (T)valueObj;
                return true;
            }

            value = default;
            return false;
        }

        private static T CreateInstance<T>() where T : new()
        {
            var instance = new T();
            Register(instance);
            return instance;
        }

        private static void AddService<T>(Type needType, T service)
        {
            Services.Add(needType, service);
            onComponentRegistered?.Invoke(needType);
        }
    }
}