using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvadersGridSpawn : MonoBehaviour
{
    public Invader[] prefabs;

   public int rows;
   public int columns;

   public int choice;

   public float speed = 1.0f;
   
   private Vector3 _direction = Vector2.right;
    private void Awake ()
    {
        for (int row = 0; row < this.rows; row++)
        {
            choice = row;
            if (choice > this.prefabs.Length - 1){
                choice = Random.Range(0,3); 
            }

            float width = 1.75f * (this.columns - 1);
            float height = 2.0f * (this.rows - 1);
            Vector2 centering = new Vector2 (-width/2, -height/2);
            Vector2 rowPosition = new Vector2(centering.x, centering.y + (row * 1.75f));

            for (int col = 0; col < this.columns; col++)
            {
                Invader invader = Instantiate(this.prefabs[choice], this.transform);

                Vector2 position = rowPosition;
                position.x += col * 2.0f;
                position.y += 3.0f;
                invader.transform.position = position;
            }
        }
    }

    private void Update()
    {
        this.transform.position += _direction * this.speed * Time.deltaTime;

        Vector3 leftSide = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightSide = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in this.transform)
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

    private void Advance()
    {
        _direction.x *= -1;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position; 
    }
}
