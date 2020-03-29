namespace MRCR_V1
{ 
    class MoveAhead : BTNode
    {
        private double moveDistance;
        private bool useRandom;
        private bool bullCharge;
        public MoveAhead(BlackBoard blackBoard, double movePixels, bool useRandom = false, bool bullCharge = false)
        {
            this.useRandom = useRandom;
            this.bullCharge = bullCharge;
            this.blackBoard = blackBoard;
            moveDistance = movePixels;
        }
        public override BTNodeStatus Tick()
        {
            if (useRandom)
            {
                moveDistance = (100 - -100) * blackBoard.random.NextDouble() + -100;
            }
            else if (bullCharge)
            {
                moveDistance = blackBoard.lastScannedRobotEvent.Distance + 50;
            }
            blackBoard.robot.Ahead(moveDistance);

            return BTNodeStatus.succes;
        }
    }
}
