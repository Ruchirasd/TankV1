using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankV1.Canvas_Structure
{
    class LifePack: CanvasStructure
    {
        String time;
        public LifePack(String x, String y, String time) : base(x, y) {
            this.time = time;
           
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }
    }
}
