using NeonTools.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NeonTools.Module
{
    class ModuleBase : MonoBehaviour
    {
        protected ScaleUtil scl = new ScaleUtil(Screen.width, Screen.height);

        protected int xStart, yStart;

        public ModuleBase()
        {
            fixSpacing(true);
        }

        protected void fixSpacing(bool force = false)
        {
            if ((Screen.width != scl.originalWid || Screen.height != scl.originalHei) || force)
            {
                int[] scale = scl.ScaledSpacing(Screen.width, Screen.height);
                xStart = scale[0];
                yStart = scale[1];
            }
        }
    }
}
