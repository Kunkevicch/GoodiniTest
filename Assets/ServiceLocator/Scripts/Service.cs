using UnityEngine;

namespace Goodini
{
    public abstract class Service : MonoBehaviour
    {
        protected IServiceLocator<Service> _locator;
    }
}
