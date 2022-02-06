using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  public Vector3 direction;
  public float speed;

  private void Update()
  {
      this.transform.position += this.direction * this.speed * Time.deltaTime;
  }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
    }

    private void OnBecameInvisible()
    {
         Destroy(this.gameObject);
    }

}
