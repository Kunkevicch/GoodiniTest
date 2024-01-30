using System;
using UnityEngine;

namespace Goodini
{
    public class CityInput : Service
    {
        public event Action<Vector2> JoystickMoved;

        public event Action<Vector3> BuildingChoosed;

        public event Action<Vector2> PointerMoved;

        public event Action Reseted;

        private CityUI _cityUI;

        private Joystick _joystick;

        private void Awake()
        {
            CitySpawnerServiceLocator.LocatorInited += OnLocatorInited;
            ControlBtn.BuildingChoosed += OnBuildingChoosed;
        }

        protected void OnLocatorInited(IServiceLocator<Service> locator)
        {
            _locator = locator;
            _cityUI = _locator.Get<CityUI>();
            SubscribOnUI();
            _joystick = _cityUI.JoyStick;
        }

        private void SubscribOnUI()
        {
            _cityUI.ResetBTN.onClick.AddListener(OnResetBtnClicked);
            _cityUI.TouchPad.pointerMove += OnPointerMove;
        }

        private void OnBuildingChoosed(Vector3 buildingPosition)
        {
            BuildingChoosed?.Invoke(buildingPosition);
        }

        private void OnResetBtnClicked()
        {
            Reseted?.Invoke();
        }

        private void OnPointerMove(Vector2 direction)
        {
            PointerMoved?.Invoke(direction);
        }

        private void Update()
        {
            if ( _joystick == null ) return;

            if ( _joystick.Horizontal != 0 || _joystick.Vertical != 0 )
            {
                JoystickMoved?.Invoke(_joystick.Direction);
            }
        }
    }
}