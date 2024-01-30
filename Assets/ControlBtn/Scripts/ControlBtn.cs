using System;
using UnityEngine;

namespace Goodini
{
    public class ControlBtn : MonoBehaviour
    {
        public static Action<Vector3> BuildingChoosed;

        public void ChooseBuilding(Transform transform)
        {
            BuildingChoosed.Invoke(transform.position);
        }
    }
}