public static class BonusFactory
{
    public static int DoubleBallBonusPercent { get; set; } = 20;
    public static IBonus GetDoubleBallBonusCommand()
    {
        return new DoubleBallBonusCommand(DoubleBallBonusPercent);
    }
}
