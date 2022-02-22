using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // this thing is the library for moving between scenes

public class Player : MonoBehaviour
{
    public float moveSpeed; // tell us how fast our fish can move
    public SpriteRenderer sprite;
    public float size; // the current size of our fish
    public GameObject GameOverCanvas; 
    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.SetActive(false); // start the game with the gameover canvas not active
        Time.timeScale = 1; // make sure the game is unpaused when we start
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(size, size, 1); // contantly update the size of the fish
        if (Input.GetKey(KeyCode.W)) // if the input is the W key
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) // if the input is the D key
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            sprite.flipX = false; // make it face right
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            sprite.flipX = true; // make it face left
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish")) // checking if the thing we're colliding is a fish
        {
            if(size >= collision.gameObject.transform.localScale.x) // if we're bigger than the fish we're colliding with, eat it and gain size
            {
                Destroy(collision.gameObject); // destroy the fish
                size += 0.1f; // small size increase after eating a fish
            }
            else // if we aren't the bigger fish
            {
                Time.timeScale = 0; // cheap and dirty way to pause our game (stops the scripts from updating)
                GameOverCanvas.SetActive(true); // display the canvas
            }
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(0); // loadscene can take in the levels index (what # the level is in the order of levels, or the name of the level)
    }
}
