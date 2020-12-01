using UnityEngine;

public class Racket : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Color _colorFromSettings;

    private readonly StorageProvider _storageProvider = new StorageProvider();

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();

        _colorFromSettings = _storageProvider.LoadRacketColor();

        _sprite.color = _colorFromSettings;
    }
}
