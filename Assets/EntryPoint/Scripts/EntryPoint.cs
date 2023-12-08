using UnityEngine;

namespace Goodini
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private CameraController _cameraController;

        [SerializeField]
        private CityUI _cityUI;

        [SerializeField]
        private CitySpawnerServiceLocator _citySpawnerServiceLocator;

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