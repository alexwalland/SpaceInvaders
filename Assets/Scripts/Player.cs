using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float speed = 5.0f;

   public Projectile pLazer;
   public float firerate = 1.0f;

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

}
