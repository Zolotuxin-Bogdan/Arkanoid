public static class BonusFactory
{
    public static int DoubleBallBonusPercent { get; set; } = 20;
    public static int SlowMoBonusPercent { get; set; } = 10;

    public static IBonus GetDoubleBallBonusCommand()
    {
        return new DoubleBallBonusCommand(DoubleBallBonusPercent);
    }

    public static IBonus GetSlowMoBonusCommand()
    {
        return new SlowMoBonusCommand(SlowMoBonusPercent);
    }
}
