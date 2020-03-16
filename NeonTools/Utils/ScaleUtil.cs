using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonTools.Utils
{
    class ScaleUtil
    {
        private static int BaseWidth = 1920, BaseHeight = 1080;
        private static int BaseWidthSpacing = 90, BaseHeightSpacing = 140;

        public int originalWid, originalHei;
        public ScaleUtil(int wid, int hei)
        {
            originalWid = wid;
            originalHei = hei;
        }

        public int[] ScaledSpacing(int wid, int hei)
        {
            originalWid = wid;
            originalHei = hei;

            int spacingWid = (originalWid * BaseWidthSpacing) / BaseWidth;
            int spacingHei = (originalHei * BaseHeightSpacing) / BaseHeight;
            return new int[] {spacingWid, spacingHei};
        }
    }
}
