using UnityEngine;

public class CustomColor
{
    public float RedColor { get; set; } = 255f;
    public float GreenColor { get; set; } = 255f;
    public float BlueColor { get; set; } = 255f;

    public static implicit operator Color(CustomColor customColor)
    {
        return new Color {r = customColor.RedColor, g = customColor.GreenColor, b = customColor.BlueColor};
    }

    public static implicit operator CustomColor(Color color)
    {
        return new CustomColor { RedColor = color.r, GreenColor = color.g, BlueColor = color.b };
    }
}
