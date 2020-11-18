using UnityEngine;

public class RacketColor
{
    public float RedColor { get; set; } = 255f;
    public float GreenColor { get; set; } = 255f;
    public float BlueColor { get; set; } = 255f;

    public static implicit operator Color(RacketColor racketColor)
    {
        return new Color {r = racketColor.RedColor, g = racketColor.GreenColor, b = racketColor.BlueColor};
    }
}
