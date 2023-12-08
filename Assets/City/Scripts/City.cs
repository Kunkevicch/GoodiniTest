using UnityEngine;

namespace Goodini
{

    public class City : Service
    {
        [SerializeField]
        private float _angularSpeed;

        [SerializeField]
        private Transform _buildingOne;
        public Transform BuildingOne => _buildingOne;

        [SerializeField]
        private Transform _buildingTwo;
        public Transform BuildingTwo => _buildingTwo;

        [SerializeField]
        private Transform _buildingThree;
        public Transform BuildingThree => _buildingThree;

        [SerializeField]
        private Transform _buildingFour;
        public Transform BuildingFour => _buildingFour;

        private bool _canControl = true;


        private CityInput _cityInput;

        protected override void OnLocatorInited()
        {
            InitServices();
            SubscribeForInput();
        }

        private void InitServices()
        {
            _cityInput = _locator.Get<CityInput>();
        }

        private void SubscribeForInput()
        {
            _cityInput.joystickMoved += OnMove;
            _cityInput.pointerMoved += OnMove;
            _cityInput.buildingChoosed += OnBuildingChoosed;
            _cityInput.reseted += OnReseted;
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
