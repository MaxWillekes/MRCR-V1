using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;

namespace MRCR_V1
{
    class TurnTowardsScannedTarget : BTNode
    {
        public TurnTowardsScannedTarget(BlackBoard blackBoard)
        {
            this.blackBoard = blackBoard;
        }
        public override BTNodeStatus Tick()
        {
            double accuracyLeniency = 10;

            if (blackBoard.lastScannedRobotEvent != null)
            {
                double rotation = blackBoard.lastScannedRobotEvent.Bearing;

                if (rotation < 180)
                {
                    blackBoard.robot.TurnRight(rotation);
                }
                else
                {
                    blackBoard.robot.TurnLeft(360 - rotation);
                }

                if (Math.Abs(rotation) < accuracyLeniency)
                {
                    return BTNodeStatus.succes;
                }
                else
                {
                    return BTNodeStatus.running;
                }
            }
            return BTNodeStatus.failed;
        }
    }
}
