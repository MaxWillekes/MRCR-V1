using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;

namespace MRCR_V1
{
    class TurnGunTowardsScannedTank : BTNode
    {
        public TurnGunTowardsScannedTank(BlackBoard blackBoard)
        {
            this.blackBoard = blackBoard;
        }
        public double GetRotationToScannedRobot()
        {
            return blackBoard.lastScannedRobotEvent.Bearing -
                    (blackBoard.robot.GunHeading - blackBoard.robot.Heading);
        }
        public override BTNodeStatus Tick()
        {
            double accuracyLeniency = 10;

            if (blackBoard.lastScannedRobotEvent != null)
            {
                double rotation = GetRotationToScannedRobot();

                if (rotation < 180)
                {
                    blackBoard.robot.TurnGunRight(rotation);
                }
                else
                {
                    blackBoard.robot.TurnGunLeft(360 - rotation);
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