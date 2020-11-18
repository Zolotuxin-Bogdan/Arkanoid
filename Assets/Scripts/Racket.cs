using UnityEngine;

public class Racket : MonoBehaviour
{
    public StorageProvider StorageProvider;

    private SpriteRenderer _sprite;
    private Color _colorFromSettings;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();

        _colorFromSettings = StorageProvider.LoadRacketColor();

        _sprite.color = _colorFromSettings;
    }
}
