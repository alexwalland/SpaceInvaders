using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvadersGridSpawn : MonoBehaviour
{
    public Invader[] prefabs;

   public int rows;
   public int columns;
   public int choice;

   public AnimationCurve speed;
   private float width;
   private float height;

   private Vector2 centering;
   private Vector2 rowPosition;

   public float dead = 0;
   public float totalInvaders;
   public float percentageLeft;
   public Projectile eBullet;

   private Vector3 _direction = Vector2.right;
   public float fireRate = 1f;
   
    private void Awake ()
    {
        totalInvaders = columns*rows;
        percentageLeft = dead/totalInvaders;
        for (int row = 0; row < rows; row++)
        {
            choice = row;
            if (choice > prefabs.Length - 1){
                choice = Random.Range(0,3); 
            }

            width = 1.75f * (columns - 1);
            height = 2.0f * (rows - 1);
            centering = new Vector2 (-width/2, -height/2);
            rowPosition = new Vector2(centering.x, centering.y + (row * 1.75f));

            for (int col = 0; col < columns; col++)
            {
                Invader invader = Instantiate(prefabs[choice], transform);

                Vector2 position = rowPosition;
                position.x += col * 2.0f;
                position.y += 5.0f;
                invader.transform.position = position;
            }
        }
    }

    private void Start() 
    {
        InvokeRepeating(nameof(shoot), fireRate, fireRate);    
    }

    private void Update()
    {
        deathCheck();
        transform.position += _direction * speed.Evaluate(percentageLeft) * Time.deltaTime;

        Vector3 leftSide = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightSide = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (_direction == Vector3.right && invader.position.x >= (rightSide.x - 1f))
            {
                Advance();
            } else if (_direction == Vector3.left && invader.position.x <= (leftSide.x + 1f))
            {
                Advance();
            }
        }
    }

    private void shoot()
    {
         foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (Random.value < (1 / (totalInvaders - dead)))
            {
                Instantiate(eBullet, invader.position, Quaternion.identity);
                break;
            }
        }

    }

    private void Advance()
    {
        _direction.x *= -1;

        Vector3 position = transform.position;
        position.y -= 1.0f;
        transform.position = position; 
    }

    public void addRow()
    {
        totalInvaders += rows;
        rows++;
        choice = Random.Range(0,3); 
        width = 1.75f * (columns - 1);
        height = 2.0f * (rows - 1);

            for (int col = 0; col < columns; col++)
            {
                Invader invader = Instantiate(prefabs[choice], transform);

                Vector2 position = rowPosition;
                invader.transform.position = position;
            }
            
    }

    public void deathCheck()
    {
        float currentDead = 0;
           foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                currentDead++;
            }
        }
        dead = currentDead;
        percentageLeft = dead / totalInvaders;

        if (percentageLeft == 1)
        {
            reset();
        }
    }

    private void reset()
    {
        transform.position = new Vector2 (0,0);
        foreach (Transform invader in transform)
        {
            invader.gameObject.SetActive(true);
        }
        
    }
    
    
}
