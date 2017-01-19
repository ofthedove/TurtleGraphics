using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleGraphics
{
    enum StepSize { Nintey = 90, Sixty = 60, FourtyFive = 45, Thirty = 30, Ten = 10 }
    class Turtle
    {
        private const int FORWARD_DISTANCE = 20;
        private const StepSize stepSize = StepSize.Thirty;

        private TurtleState currentState;

        public Turtle()
        {
            currentState = new TurtleState() { XCoord = 0, YCoord = 0 };
        }

        public Tuple<int, int> GetLocation()
        {
            return new Tuple<int, int>(currentState.XCoord, currentState.YCoord);
        }

        public void TurnRight()
        {
            currentState.Direction = currentState.Direction - (int)stepSize;
        }

        public void TurtLeft()
        {
            currentState.Direction = currentState.Direction + (int)stepSize;
        }

        public Tuple<int, int> GoForward()
        {
            double dirRad = (double)currentState.Direction * Math.PI / 180.0;
            int xDist = (int)(FORWARD_DISTANCE * Math.Sin(dirRad));
            int yDist = (int)(FORWARD_DISTANCE * Math.Cos(dirRad));

            currentState.XCoord += xDist;
            currentState.YCoord += yDist;

            return new Tuple<int, int>(currentState.XCoord, currentState.YCoord);
        }

        public void SaveState()
        {
            TurtleState newState = new TurtleState();
            newState.Direction = currentState.Direction;
            newState.XCoord = currentState.XCoord;
            newState.YCoord = currentState.YCoord;
            newState.PreviousState = currentState;
            currentState = newState;
        }

        public void RecallState()
        {
            TurtleState newState = new TurtleState();
            newState.Direction = currentState.PreviousState.Direction;
            newState.XCoord = currentState.PreviousState.XCoord;
            newState.YCoord = currentState.PreviousState.YCoord;
            newState.PreviousState = currentState.PreviousState;
            currentState = newState;
        }
    }
}
