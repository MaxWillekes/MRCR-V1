namespace MRCR_V1
{
    class HealthCheck : BTNode
    {

        private bool phaseThreePossible;
        public HealthCheck(BlackBoard blackBoard, bool phaseThreePossible = false)
        {
            this.phaseThreePossible = phaseThreePossible;
            this.blackBoard = blackBoard;
        }
        public override BTNodeStatus Tick()
        {
            if (blackBoard.robot.Energy < 66 && phaseThreePossible == false)
            {
                return BTNodeStatus.failed;
            }
            else if(blackBoard.robot.Energy < 33 && phaseThreePossible)
            {
                return BTNodeStatus.failed;
            }
            else
            {
                return BTNodeStatus.succes;
            }
        }
    }
}
