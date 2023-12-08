using UnityEngine;

namespace Goodini
{
    public class CameraController : MonoBehaviour, IInitable
    {
        [SerializeField]
        private float _angularSpeed;

        [SerializeField]
        private float _verticalSpeed;

        [SerializeField]
        private Transform _cameraTargetView;

        private Vector3 _startPosition;

        private IServiceLocator<Service> _locator;
        private CityInput _cityInput;

        private bool _canControl;

        public void Init()
        {
            CitySpawnerServiceLocator.locatorInited += OnLocatorInited;
            _startPosition = _cameraTargetView.position;
        }

        private void OnLocatorInited(IServiceLocator<Service> locator)
        {
            InitLocator(locator);
            InitServices();
            SubscribeOnInput();
        }

        private void InitLocator(IServiceLocator<Service> locator)
        {
            _locator = locator;
        }

        private void InitServices()
        {
            _cityInput = _locator.Get<CityInput>();
        }

        private void SubscribeOnInput()
        {
            _cityInput.buildingChoosed += OnBuildingChoosed;
            _cityInput.joystickMoved += OnJoystickMoved;
            _cityInput.pointerMoved += OnJoystickMoved;
            _cityInput.reseted += OnReseted;
        }

        private void OnJoystickMoved(Vector2 direction)
        {
            MoveAndRotate(direction);
        }

        private void MoveAndRotate(Vector2 direction)
        {
            if ( !_canControl ) return;

            if ( _cameraTargetView.position.y < 0.5f )
            {
                _cameraTargetView.position = new Vector3(_cameraTargetView.position.x, 0.5f, _cameraTargetView.position.z);
            }
            else if ( _cameraTargetView.position.y > 3f )
            {
                _cameraTargetView.position = new Vector3(_cameraTargetView.position.x, 3f, _cameraTargetView.position.z);
            }
            else
            {
                Vector3 newDirection = new Vector3(0f, direction.y, 0f);

                _cameraTargetView.Translate(newDirection * _verticalSpeed * Time.deltaTime);
            }

            float angle = direction.x * Time.deltaTime * _angularSpeed;
            _cameraTargetView.Rotate(0, angle, 0);
        }

        private void OnBuildingChoosed(Vector3 buidlingPosition)
        {
            _cameraTargetView.transform.position = buidlingPosition;
            _canControl = true;
        }
    
        private void OnReseted()
        {
            _canControl = false;
            ResetView();
        }

        private void ResetView()
        {
            _cameraTargetView.position = _startPosition;
            _cameraTargetView.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}