using UnityEngine;

namespace Goodini
{

    public class City : Service
    {
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
    }
}
