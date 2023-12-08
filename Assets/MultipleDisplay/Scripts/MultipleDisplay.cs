using UnityEngine;

namespace Goodini
{
    public class MultipleDisplay : MonoBehaviour
    {
        private void Start()
        {
#if !UNITY_EDITOR

            for ( int i = 0; i < Display.displays.Length; i++) 
            {
                Display.displays[i].Activate();
            }
#endif

        }
    }
}
