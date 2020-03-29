namespace MRCR_V1
{
    class Turn : BTNode
    {
        private double turnAmmount;
        private bool useRandom;
        public Turn(BlackBoard blackBoard, double movePixels, bool useRandom = false)
        {
            this.useRandom = useRandom;
            this.blackBoard = blackBoard;
            turnAmmount = movePixels;
        }
        public override BTNodeStatus Tick()
        {
            if (useRandom)
            {
                turnAmmount = (180 - -180) * blackBoard.random.NextDouble() + -180;
            }
            blackBoard.robot.TurnRight(turnAmmount);

            return BTNodeStatus.succes;
        }
    }
}