using UnityEngine;

namespace Goodini
{

    public class City : Service
    {
        [SerializeField]
        private float _angularSpeed;

        [SerializeField]
        private Transform[] _buildings;
        public Transform[] Buildings => _buildings;

        private bool _canControl = true;

        private CityInput _cityInput;

        private void Awake()
        {
            CitySpawnerServiceLocator.LocatorInited += OnLocatorInited;
        }

        protected void OnLocatorInited(IServiceLocator<Service> locator)
        {
            _locator = locator;
            InitServices();
            SubscribeForInput();
        }

        private void InitServices()
        {
            _cityInput = _locator.Get<CityInput>();
        }

        private void SubscribeForInput()
        {
            _cityInput.JoystickMoved += OnMove;
            _cityInput.PointerMoved += OnMove;
            _cityInput.BuildingChoosed += OnBuildingChoosed;
            _cityInput.Reseted += OnReseted;
        }

        private void OnMove(Vector2 direction)
        {
            if ( !_canControl ) return;
            float angle = direction.x * Time.deltaTime * _angularSpeed;
            transform.Rotate(0, angle, 0);
        }

        private void OnBuildingChoosed(Vector3 buildingPosition)
        {
            _canControl = false;
        }

        private void OnReseted()
        {
            _canControl = true;
        }
    }
}
