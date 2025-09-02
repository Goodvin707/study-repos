using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESUM
{
    class ColorPackage
    {
        public Color dg, dgCells, tp, menuStrip, toolStrip, statusStrip, splitContainer1, splitContainer2, tree, propertyPanel;
        public static int currentAppStyle = 0;

        public ColorPackage(int appStyle)
        {
            switch (appStyle)
            {
                case 0:
                    this.dg = Color.White;
                    this.dgCells = Color.FromArgb(224, 224, 224);
                    this.tp = Color.White;
                    this.menuStrip = Color.FromArgb(240, 240, 240);
                    this.toolStrip = Color.FromArgb(224, 224, 224);
                    this.statusStrip = Color.FromArgb(224, 224, 224);
                    this.splitContainer1 = Color.FromArgb(224, 224, 224);
                    this.splitContainer2 = Color.FromArgb(224, 224, 224);
                    this.tree = Color.White;
                    this.propertyPanel = Color.White;
                    break;
                case 1:
                    this.dg = Color.Lavender;
                    this.dgCells = Color.LightPink;
                    this.tp = Color.Lavender;
                    this.menuStrip = Color.MediumPurple;
                    this.toolStrip = Color.SlateBlue;
                    this.statusStrip = Color.LavenderBlush;
                    this.splitContainer1 = Color.SteelBlue;
                    this.splitContainer2 = Color.Lavender;
                    this.tree = Color.Lavender;
                    this.propertyPanel = Color.Lavender;
                    break;
                case 2:
                    this.dg = Color.DarkSlateBlue;
                    this.dgCells = Color.FromArgb(170, 96, 221); // Color.FromArgb(0, 136, 204);
                    this.tp = Color.Lavender;
                    this.menuStrip = Color.FromArgb(35, 31, 92);
                    this.toolStrip = Color.FromArgb(40, 63, 96);
                    this.statusStrip = Color.FromArgb(5, 89, 142);
                    this.splitContainer1 = Color.SteelBlue;
                    this.splitContainer2 = Color.FromArgb(5, 89, 142);
                    this.tree = Color.FromArgb(5, 49, 92);
                    this.propertyPanel = Color.FromArgb(5, 49, 92);
                    break;
                case 3:
                    this.dg = Color.Lavender;
                    this.dgCells = Color.LightBlue;
                    this.tp = Color.Lavender;
                    this.menuStrip = Color.FromArgb(42, 90, 253);
                    this.toolStrip = Color.FromArgb(42, 150, 233);
                    this.statusStrip = Color.FromArgb(122, 170, 253);
                    this.splitContainer1 = Color.FromArgb(1, 1, 185);
                    this.splitContainer2 = Color.FromArgb(1, 1, 185);
                    this.tree = Color.SkyBlue;
                    this.propertyPanel = Color.SkyBlue;
                    break;
                case 4:
                    this.dg = Color.Lavender;
                    this.dgCells = Color.FromArgb(234, 255, 233);
                    this.tp = Color.Lavender;
                    this.menuStrip = Color.MediumSeaGreen;
                    this.toolStrip = Color.SeaGreen;
                    this.statusStrip = Color.LightYellow;
                    this.splitContainer1 = Color.AliceBlue;
                    this.splitContainer2 = Color.AliceBlue;
                    this.tree = Color.FromArgb(234, 255, 245);
                    this.propertyPanel = Color.FromArgb(234, 255, 245);
                    break;
            }
        }
    }
}