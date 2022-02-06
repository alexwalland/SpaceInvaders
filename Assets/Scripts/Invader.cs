using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationsprites;
    public Sprite death;

    private float framerate = 0.5f;

    private SpriteRenderer _spriterenderer;

    private int _animationframe;
    public int score;
    public float d = 0;
    public float fireRate = 1f;

    public InvadersGridSpawn invadersGridSpawn;

    private void Awake()
    {
        _spriterenderer = GetComponent<SpriteRenderer>();

    }
    private void Start()
    {
        InvokeRepeating(nameof(Changeanimation), framerate, framerate);
    }

    private void Update()
    {
        d += Time.deltaTime;
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

    private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("pBullet"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
