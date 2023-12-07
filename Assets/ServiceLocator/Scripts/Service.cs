using UnityEngine;

namespace Goodini
{
    public abstract class Service : MonoBehaviour
    {
        protected IServiceLocator<Service> _locator;

        public void InitLocator<T>(IServiceLocator<T> locator)
        {
            _locator = locator as ServiceLocator<Service>;
            _locator.LocatorInited += OnLocatorInited;
        }

        protected virtual void OnLocatorInited()
        {}
    }
}
