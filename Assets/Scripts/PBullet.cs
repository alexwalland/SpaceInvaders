using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = Vector2.up * GlobalVariables.speed;
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "wall")
        {
            Destroy(gameObject);
        }
    }

    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }
}
