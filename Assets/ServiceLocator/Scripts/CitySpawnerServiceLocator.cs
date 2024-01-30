using System;
using System.Collections.Generic;
using UnityEngine;

namespace Goodini
{
    public class CitySpawnerServiceLocator : Initable
    {
        public static event Action<IServiceLocator<Service>> LocatorInited;
        
        private IServiceLocator<Service> _locator;
        public IServiceLocator<Service> Locator => _locator;
        
        [SerializeField]
        List<ServiceForLocate> _locatedServices;

        [System.Serializable]
        class ServiceForLocate
        {
            public Service service;
            public Vector3 position;
            public bool needToSpawn;
        }

        public override void Init()
        {
            _locator = new ServiceLocator<Service>();
            SpawnRegisterServices();
            LocatorInited?.Invoke(_locator);
        }

        private void SpawnRegisterServices()
        {
            foreach (ServiceForLocate service in _locatedServices)
            {
                if (service.needToSpawn)
                {
                    Service newService = Instantiate(service.service, service.position, Quaternion.identity);
                    _locator.Register(newService);
                }
                else
                {
                    _locator.Register(service.service);
                }
            }
        }
    }
}
