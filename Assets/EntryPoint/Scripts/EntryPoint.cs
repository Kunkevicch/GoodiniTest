using UnityEngine;

namespace Goodini
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private Initable[] _initables;

        private void Start()
        {
            InitSystems();
        }

        private void InitSystems()
        {
            for(int i=0;i< _initables.Length;i++)
            {
                _initables[i].Init();
            }
        }
    }
}