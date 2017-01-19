using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace TurtleGraphics
{
    class TurtleState
    {
        private int direction = 0;

        public int Direction
        {
            get { return direction; }
            set
            {
                direction = value;
                // Check for overflow
                direction = (direction >= 360) ? direction - 360 : direction;
                // Chcek for underflow
                direction = (direction < 0) ? direction + 360 : direction;
            }
        }
        public int XCoord { get; set; } = 0;
        public int YCoord { get; set; } = 0;

        public TurtleState PreviousState { get; set; } = null;
    }
}
