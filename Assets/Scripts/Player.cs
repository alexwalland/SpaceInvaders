using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;

    float shootDelay = 0.5f;
    float timer = 1;

    void FixedUpdate ()
    {
        float move = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move, 0) * GlobalVariables.speed;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButtonDown("shoot") && timer > shootDelay)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
