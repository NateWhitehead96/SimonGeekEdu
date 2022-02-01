using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public Direction direction; // help point the fish in the right direction

    public float timer; // a countdown to spawn the fish

    public GameObject fishToSpawn; // the prefab fish we want to spawn
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
            GameObject newFish = Instantiate(fishToSpawn, transform.position, transform.rotation); // create a new fish at our position and rotation
            newFish.GetComponent<Fish>().direction = direction; // make sure the fish we spawn has the same direction as the spawner
            timer = 2; // reset timer
        }
    }
}
