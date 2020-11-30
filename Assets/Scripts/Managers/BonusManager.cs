using UnityEngine;
using Random = System.Random;

public class BonusManager : MonoBehaviour
{
    public static BonusManager Instance { get; private set; }

    private IBonus _bonus;

    [Range(0, 100)]
    public int DoubleBallPercent;

    [Range(0, 100)]
    public int SlowMoPercent;
    
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ApplyBonusEffect()
    {
        _bonus.Execute();
    }

    public void SetBonusCommand(IBonus bonus)
    {
        _bonus = bonus;
    }



    public void TryGetDoubleBall()
    {
        var percentValue = _randomGen.Next(100);
        if (percentValue < DoubleBallPercent)
        {
            BallManager.Instance.SpawnDoubleBall();
        }
    }

    public void TryGetSlowMo()
    {

    }
}
