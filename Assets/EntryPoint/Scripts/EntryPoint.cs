using UnityEngine;

namespace Goodini
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private CitySpawnerServiceLocator _citySpawnerServiceLocator;

        [SerializeField]
        private CameraController _cameraController;

        private void Awake()
        {
            InitSystems();
        }

        private void InitSystems()
        {
            _cameraController.Init();
            _citySpawnerServiceLocator.Init();
        }
    }
}