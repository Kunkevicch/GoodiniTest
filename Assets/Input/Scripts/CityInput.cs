using System;
using UnityEngine;

namespace Goodini
{
    public class CityInput : Service
    {
        public event Action<Vector2> joystickMoved;

        public event Action<Vector3> buildingChoosed;

        public event Action<Vector2> pointerMove;

        public event Action reseted;

        private bool _isControlled;

        private CityUI _cityUI;
        private Joystick _joystick;
        private City _city;

        protected override void OnLocatorInited()
        {
            _cityUI = _locator.Get<CityUI>();
            SubscribOnUI();
            _city = _locator.Get<City>();
            _joystick = _cityUI.JoyStick;
        }

        private void SubscribOnUI()
        {
            _cityUI.BuildingOneBTN.onClick.AddListener(OnFirstBtnClicked);
            _cityUI.BuildingTwoBTN.onClick.AddListener(OnSecondBtnClicked);
            _cityUI.BuildingThreeBTN.onClick.AddListener(OnThirdBtnClicked);
            _cityUI.BuildingFourBTN.onClick.AddListener(OnFourthBtnClicked);
            _cityUI.ResetBTN.onClick.AddListener(OnResetBtnClicked);
            _cityUI.TouchPad.pointerMove += OnPointerMove;
        }

        private void OnFirstBtnClicked()
        {
            buildingChoosed?.Invoke(_city.BuildingOne.transform.position);
            _isControlled = true;
        }

        private void OnSecondBtnClicked()
        {
            buildingChoosed?.Invoke(_city.BuildingTwo.transform.position);
            _isControlled = true;
        }

        private void OnThirdBtnClicked()
        {
            buildingChoosed?.Invoke(_city.BuildingThree.transform.position);
            _isControlled = true;
        }

        private void OnFourthBtnClicked()
        {
            buildingChoosed?.Invoke(_city.BuildingFour.transform.position);
            _isControlled = true;
        }

        private void OnResetBtnClicked()
        {
            reseted?.Invoke();
            _isControlled = false;
        }

        private void OnPointerMove(Vector2 direction)
        {
            if ( !_isControlled ) return;
            pointerMove?.Invoke(direction);
        }

        private void Update()
        {
            if ( _joystick == null ) return;

            if ( _isControlled )
            {
                if ( _joystick.Horizontal != 0 || _joystick.Vertical != 0 )
                {
                    joystickMoved?.Invoke(_joystick.Direction);
                }
            }
        }
    }
}