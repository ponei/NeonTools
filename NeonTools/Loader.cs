using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NeonTools
{
    class Loader
    {
        public static void Init()
        {
            toolsObject = new GameObject();
            toolsObject.AddComponent<Checkpoints>();
            toolsObject.AddComponent<Speed>();
            GameObject.DontDestroyOnLoad(toolsObject);
        }
        public static void Unload()
        {
            _Unload();
        }
        private static void _Unload()
        {
            GameObject.Destroy(toolsObject);
        }
        private static GameObject toolsObject;
    }
}
