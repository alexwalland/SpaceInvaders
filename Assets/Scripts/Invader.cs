using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationsprites;

    private float framerate = 0.5f;

    private SpriteRenderer _spriterenderer;

    private int _animationframe;

    private void Awake()
    {
        _spriterenderer = GetComponent<SpriteRenderer>();

    }
    private void Start()
    {
        InvokeRepeating(nameof(Changeanimation), this.framerate, this.framerate);
    }

    private void Changeanimation()
    {
        _animationframe ++;

        
        if (_animationframe >= this.animationsprites.Length)
        {
            _animationframe = 0;
        }

        _spriterenderer.sprite = this.animationsprites[_animationframe];
    }
}
