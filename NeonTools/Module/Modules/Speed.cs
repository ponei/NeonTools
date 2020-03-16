using NeonTools.Module;
using NeonTools.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NeonTools
{
    class Speed : ModuleBase
    {
        private Vector3 velocity;
        private Vector3 prevPos;
        private CharacterController pc;
        private Transform pcTr;

        private Texture2D bootIcon;
        public void Start()
        {
            TextureUtil txt = new TextureUtil();
            bootIcon = txt.LoadPNG("speed");
        }

        public void FixedUpdate()
        {
            velocity = (pcTr.position - prevPos) / Time.deltaTime;
            prevPos = pcTr.position;
        }

        public void Update()
        {
            fixSpacing();
            if (FindObjectOfType<CharacterController>() != pc)
            {
                pc = FindObjectOfType<CharacterController>();
                pcTr = pc.transform;
            }
        }

        public void OnGUI()
        {
            if (pc != null)
            {

                GUI.DrawTexture(new Rect(xStart, yStart, 50, 50), bootIcon);

                if (!pc._isTeleporting)
                {
                    float x = 0 > velocity.x ? velocity.x * -1 : velocity.x;
                    float y = 0 > velocity.y ? velocity.y * -1 : velocity.y;
                    double speed = Math.Sqrt((x * x) + (y * y));
                    GUI.Label(new Rect(xStart + 60, yStart + 13, 150f, 50f), Math.Round(speed, 2) + "m/s");
                } else
                {
                    GUI.Label(new Rect(xStart + 60, yStart + 13, 150f, 50f), "0m/s");
                }
            }
        }
    }
}
