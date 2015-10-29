using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankV1.Canvas_Structure
{
    class Coin: CanvasStructure
    {
        private String time;
        private String value;

        public Coin(String x, String y, String time, String value) : base(x, y) {
            this.time = time;
            this.value = value;
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

        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }
    }
}
