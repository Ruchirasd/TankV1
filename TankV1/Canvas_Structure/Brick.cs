using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankV1.Canvas_Structure
{
    class Brick : CanvasStructure
    {
        String damageLevel;

        public Brick(String x, String y, String damageLevel) : base(x, y) {
            this.damageLevel = damageLevel;
        }

        public string DamageLevel
        {
            get
            {
                return damageLevel;
            }

            set
            {
                damageLevel = value;
            }
        }
    }
}
