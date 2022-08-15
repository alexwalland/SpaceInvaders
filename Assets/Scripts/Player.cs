using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
   public float speed = 5.0f;
   private SpriteRenderer player;

   public Projectile pLazer;
   public float firerate = 1.0f;

   public int score = 0;

   public Sprite death;
   public Sprite live;
   public AudioClip _death;
   public int lives = 3;
   public Text ScoreT;
   public Text LivesT;

   void Awake()
   {
       player = GetComponent<SpriteRenderer>();
       player.sprite = live;
       LivesT.text = lives.ToString();
   }

    void Update()
    {
        firerate += Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && firerate >= 1)
        {
            Shoot();
            firerate = 0.5f;
        }
    }

    private void Shoot()
    {
        Instantiate(this.pLazer, this.transform.position, Quaternion.identity);
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("missle") && lives > 0)
        {
            lives--;
            GetComponent<Collider2D>().enabled = false;
            player.sprite = death;
            Invoke("reload", 0.25f);
            speed = 0f;
        } 
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void reload() {
        player.sprite = live;
        GetComponent<Collider2D>().enabled = true;
        speed = 5.0f;
        LivesT.text = lives.ToString();
    }

}

