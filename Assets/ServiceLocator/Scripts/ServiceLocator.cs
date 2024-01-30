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
                throw new Exception($"������ � ����� {type} ��� ��������������� � ������ ��������!");
            }

            _services[type] = newService;

            return newService;
        }

        public void Unregister<TT>(TT service) where TT : T
        {
            var type = service.GetType();
            if ( !_services.ContainsKey(type) )
            {
                Debug.LogError($"������ � ����� {type} �� ������ � ������ ��������");
                return;
            }

            _services.Remove(service.GetType());

        }

        public TT Get<TT>() where TT : T
        {
            var type = typeof(TT);

            if ( !_services.ContainsKey(type) )
            {
                throw new Exception($"������ � ����� {type} �� ��������������� � ������ ��������!");
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
