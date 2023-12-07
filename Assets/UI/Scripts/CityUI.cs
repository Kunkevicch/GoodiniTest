using UnityEngine;
using UnityEngine.UI;

namespace Goodini
{
    public class CityUI : Service
    {
        [SerializeField]
        private Joystick _joyStick;

        public Joystick JoyStick => _joyStick;

        [SerializeField]
        private Button _buildingOneBTN;

        public Button BuildingOneBTN => _buildingOneBTN;

        [SerializeField]
        private Button _buildingTwoBTN;

        public Button BuildingTwoBTN => _buildingTwoBTN;

        [SerializeField]
        private Button _buildingThreeBTN;

        public Button BuildingThreeBTN => _buildingThreeBTN;

        [SerializeField]
        private Button _buildingFourBTN;

        public Button BuildingFourBTN => _buildingFourBTN;

        [SerializeField]
        private Button _resetBTN;

        public Button ResetBTN => _resetBTN;

        [SerializeField]
        private TouchPad _touchPad;

        public TouchPad TouchPad => _touchPad;

        protected override void OnLocatorInited()
        {
        }
    }
}