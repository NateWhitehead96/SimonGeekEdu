using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Right,
    Down,
    Left
}

public class Fish : MonoBehaviour
{
    public float moveSpeed; // how fast the fishy can swim
    public Direction direction;

    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // auto set the sprite in this script to the sprite on the gameobject of this script
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == Direction.Up)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        if (direction == Direction.Right)
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        if (direction == Direction.Down)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
        if (direction == Direction.Left)
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            sprite.flipX = true; // flips it to face left
        }

        // bounds check
        if(transform.position.x > 13 || transform.position.x < -13 || transform.position.y > 8 || transform.position.y < -8)
        {
            Destroy(gameObject);
        }

    }
}
