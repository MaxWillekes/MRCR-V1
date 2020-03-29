using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Robocode;
using System.Drawing;
using Robocode.Util;

namespace MRCR_V1
{
    public class PartyBot : AdvancedRobot
    {
        public BTNode BeahaviorTree;
        public BlackBoard blackBoard = new BlackBoard();

        Random random = new Random();
        Color color;

        public override void Run()
        {
            blackBoard.robot = this;
            blackBoard.random = random;

            BeahaviorTree = new Selector(blackBoard,
                //Phase 1
                new Sequence(blackBoard,
                    new HealthCheck(blackBoard),
                    new ScanRobot(blackBoard, 360),
                    new TurnGunTowardsScannedTank(blackBoard),
                    new Shoot(blackBoard)
                ),
                //Phase 2
                new Sequence(blackBoard,
                    new HealthCheck(blackBoard, true),
                    new MoveAhead(blackBoard, 0, true),
                    new Turn(blackBoard, 0, true),
                    new MoveAhead(blackBoard, 0, true),
                    new ScanRobot(blackBoard, 360),
                    new TurnGunTowardsScannedTank(blackBoard),
                    new Shoot(blackBoard)
                ),
                //Phase 3
                new Sequence(blackBoard,
                    new ScanRobot(blackBoard, 360),
                    new TurnTowardsScannedTarget(blackBoard),
                    new MoveAhead(blackBoard, 0, false, true)
                )
            );

            IsAdjustGunForRobotTurn = true;
            IsAdjustRadarForGunTurn = true;

            while (true)
            {
                BeahaviorTree.Tick();

                //---- very important ----
                int colorR = random.Next(0, 255);
                int colorG = random.Next(0, 255);
                int colorB = random.Next(0, 255);

                color = Color.FromArgb(0, colorR, colorG, colorB);

                SetAllColors(color);
                //------------------------
            }

        }
        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            Out.WriteLine("I scanned robot: " + evnt.Name);
            blackBoard.lastScannedRobotEvent = evnt;
        }
    }
}

/*//------------------------------------------------
int colorR = random.Next(0, 255);
int colorG = random.Next(0, 255);
int colorB = random.Next(0, 255);

color = Color.FromArgb(0, colorR, colorG, colorB);

SetAllColors(color);
//------------------------------------------------
Execute();*/

/*
    double RadarTurnRate = 22.5;

    int lostTargetFrameLimit = 10;
    int lostTargetForFrames = 0;

    ScannedRobotEvent foundRobot;

    public override void Run()
    {
        while (true)
        {
            //Out.WriteLine("Radar Heading  = " + RadarHeading);

            if (foundRobot != null && ( GunHeading - ((foundRobot.Bearing - 180) - (GunHeading - Heading))) < 0.0001f)
            {
                Out.WriteLine("Fire");
                //Scan();
                fire(foundRobot);
            }
            else if( foundRobot != null && lostTargetForFrames < lostTargetFrameLimit)
            {
                Out.WriteLine("TargetNoLongerThere | START");
                Out.WriteLine(foundRobot);
                //Out.WriteLine("(foundRobot.Bearing - (RadarHeading - Heading)) = " + (foundRobot.Bearing - (RadarHeading - Heading)));

                //turnRadarToEnemy(foundRobot);

                lostTargetForFrames++;
            }
            else
            {
                Out.WriteLine("TargetLost");
                lostTargetForFrames = 0;
                foundRobot = null;
                TurnRadarRight(RadarTurnRate);
            }

            Execute();
        }
    }

    public override void OnScannedRobot(ScannedRobotEvent evnt)
    {
        Out.WriteLine("TargetFound");
        foundRobot = evnt;
        Out.WriteLine("(GunHeading - Heading) == (evnt.Bearing - 180) = " + (GunHeading - Heading) + " == " + ( evnt.Bearing));

        if (((GunHeading - Heading) - (evnt.Bearing - 180)) <= 0.0001f)
        {
            fire(evnt);
        }
        else
        {
            turnGun(evnt);
        }
    }

    public void turnGun(ScannedRobotEvent evnt)
    {
        //Turn gun towards enemy
        if (GunHeading != evnt.Bearing && ((evnt.Bearing - 180) - (GunHeading - Heading)) <= evnt.Bearing)
        {
            TurnGunRight(evnt.Bearing - (GunHeading - Heading));
            turnRadarToEnemy(evnt);
            fire(evnt);
        }
        else if (GunHeading != evnt.Bearing && ((evnt.Bearing - 180) - (GunHeading - Heading)) > evnt.Bearing)
        {
            TurnGunLeft(evnt.Bearing - (GunHeading - Heading));
            turnRadarToEnemy(evnt);
            fire(evnt);
        }
    }

    public void fire(ScannedRobotEvent evnt)
    {

        lostTargetForFrames = 0;

        Fire(1);
        */
/*if (evnt.Distance < 100)
{
    Fire(3);
}
else
{
    Fire(1);
}*/
/*}

public void turnRadarToEnemy(ScannedRobotEvent evnt)
{
    if (RadarHeading != evnt.Bearing && ((evnt.Bearing - 180) - (RadarHeading - Heading)) <= evnt.Bearing)
    {
        TurnRadarRight(evnt.Bearing - (RadarHeading - Heading));
    }
    else if (RadarHeading != evnt.Bearing && ((evnt.Bearing - 180) - (RadarHeading - Heading)) > evnt.Bearing)
    {
        TurnRadarLeft(evnt.Bearing - (RadarHeading - Heading));
    }
}
}
}
*/
