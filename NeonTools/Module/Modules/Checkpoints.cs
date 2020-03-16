using NeonTools.Module;
using NeonTools.Utils;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NeonTools
{
    class Checkpoints : ModuleBase
    {
        private GameManager gm;
        private Checkpoint checkpoint;

        private Texture2D flagIcon;

        public void Start()
        {
            TextureUtil txt = new TextureUtil();
            flagIcon = txt.LoadPNG("checkpoint");
        }


        public void Update()
        {
            fixSpacing();
            if (FindObjectOfType<GameManager>() != gm)
            {
                gm = FindObjectOfType<GameManager>();
            }

            if (gm._time == 0f)
            {
                checkpoints = 0;
                times.Clear();
            }

            if (gm._checkpoint != checkpoint)
            {
                checkpoint = gm._checkpoint;
                checkpoints++;

                float secs = gm._time;
                TimeSpan time = TimeSpan.FromSeconds(secs);

                string timeFormat = string.Format("{0:D2}:{1:D2}:{2:D3}", time.Minutes, time.Seconds, time.Milliseconds);
                times.Add(timeFormat);
            }
        }

        private int checkpoints = 0;
        private List<string> times = new List<string>();
        public void OnGUI()
        {
            if (gm != null && checkpoints > 0)
            {
                GUI.DrawTexture(new Rect(xStart, yStart + 60, 50, 50), flagIcon);
                int startIndex = checkpoints >= 7 ? checkpoints - 6 : 1;
                int yAdd = 1;
                for (int i = startIndex; checkpoints >= i; i++)
                {
                    int add = 20 * yAdd;
                    yAdd++;
                    GUI.Label(new Rect(xStart + 10, yStart + 90 + add, 400f, 50f), "[" + i + "] " + times[i - 1]);
                }
            } else
            {
                checkpoints = 0;
                times.Clear();
            }
        }
    }
}
