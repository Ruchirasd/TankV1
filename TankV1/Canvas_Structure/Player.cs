using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankV1.Canvas_Structure
{
    class Player: CanvasStructure
    {
        String direction;
    
        public Player(String x, String y, String direction) : base(x, y) {
            this.direction = direction;

        }

    }
}
