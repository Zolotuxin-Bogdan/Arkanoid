using Random = System.Random;

public class DoubleBallBonusCommand : IBonus
{
    public int BonusDropPercent;
    private static Random _randomGen = new Random();

    public DoubleBallBonusCommand(int bonusDropPercent)
    {
        BonusDropPercent = bonusDropPercent;
    }
    public void Execute()
    {
        var percentValue = _randomGen.Next(100);
        if (percentValue < BonusDropPercent)
        {
            BallManager.Instance.SpawnDoubleBall();
        }
    }
}
