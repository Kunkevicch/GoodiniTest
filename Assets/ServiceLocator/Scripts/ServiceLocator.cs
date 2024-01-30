using System;
using System.Collections.Generic;
using UnityEngine;

namespace Goodini
{
    public sealed class ServiceLocator<T> : IServiceLocator<T>
    {
        private Dictionary<Type, T> _services { get; }

        public ServiceLocator()
        {
            _services = new Dictionary<Type, T>();
        }

        public TT Register<TT>(TT newService) where TT : T
        {
            var type = newService.GetType();

            if ( _services.ContainsKey(type) )
            {
                throw new Exception($"Объект с типом {type} уже зарегистрирован в данном локаторе!");
            }

            _services[type] = newService;

            return newService;
        }

        public void Unregister<TT>(TT service) where TT : T
        {
            var type = service.GetType();
            if ( !_services.ContainsKey(type) )
            {
                Debug.LogError($"Объект с типом {type} не найден в данном локаторе");
                return;
            }

            _services.Remove(service.GetType());

        }

        public TT Get<TT>() where TT : T
        {
            var type = typeof(TT);

            if ( !_services.ContainsKey(type) )
            {
                throw new Exception($"Объект с типом {type} не зарегистрирован в данном локаторе!");
            }

            return (TT)_services[type];

        }
    }

    public interface IServiceLocator<T>
    {
        TT Register<TT>(TT newService) where TT : T;
        void Unregister<TT>(TT service) where TT : T;
        TT Get<TT>() where TT : T;
    }
}
