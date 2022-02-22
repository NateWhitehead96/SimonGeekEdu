using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public Direction direction; // help point the fish in the right direction

    public float timer; // a countdown to spawn the fish

    public GameObject[] fishToSpawn; // the prefab fish we want to spawn

    public float bounds; // how far left/right or up/down the spawner can move
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; // make the timer go down in real time
        if(timer <= 0)
        {
            float randomValue = Random.Range(-bounds, bounds); // a random spot between the bounds of the spawner
            if(direction == Direction.Up || direction == Direction.Down)
            {
                transform.position = new Vector3(randomValue, transform.position.y); // if the spawner is up or down, set x to a randomvalue
            }
            if(direction == Direction.Right || direction == Direction.Left)
            {
                transform.position = new Vector3(transform.position.x, randomValue); // if the spawner is left or right, set y to randomvalue
            }
            int randomFish = Random.Range(0, fishToSpawn.Length); // finding a random fish from our array to spawn
            GameObject newFish = Instantiate(fishToSpawn[randomFish], transform.position, transform.rotation); // create a new fish at our position and rotation
            newFish.GetComponent<Fish>().direction = direction; // make sure the fish we spawn has the same direction as the spawner
            timer = Random.Range(0.5f, 2.0f); // reset timer
        }
    }
}
