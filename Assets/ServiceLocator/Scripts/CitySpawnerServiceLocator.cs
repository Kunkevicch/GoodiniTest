using System;
using System.Collections.Generic;
using UnityEngine;

namespace Goodini
{
    public class CitySpawnerServiceLocator : MonoBehaviour, IInitable
    {
        public static event Action<IServiceLocator<Service>> locatorInited;
        
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

        public void Init()
        {
            _locator = new ServiceLocator<Service>();
            SpawnRegisterServices();
            _locator.CallInited();
            locatorInited?.Invoke(_locator);
        }

        private void SpawnRegisterServices()
        {
            foreach (ServiceForLocate service in _locatedServices)
            {
                if (service.needToSpawn)
                {
                    Service newService = Instantiate(service.service, service.position, Quaternion.identity);
                    _locator.Register(newService);
                    newService.InitLocator(_locator);
                }
                else
                {
                    _locator.Register(service.service);
                }
            }
        }
    }

    public interface IInitable
    {
        public void Init();
    }
}
