using Random = System.Random;

public class SlowMoBonusCommand : IBonus
{
    public int BonusDropPercent;
    private static Random _randomGen = new Random();

    public SlowMoBonusCommand(int bonusDropPercent)
    {
        BonusDropPercent = bonusDropPercent;
    }
    public void Execute()
    {
        var percentValue = _randomGen.Next(100);
        if (percentValue < BonusDropPercent)
        {
            BallManager.Instance.SlowMoBalls();
        }
    }
}
