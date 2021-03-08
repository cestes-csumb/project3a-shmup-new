using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
     public float spawnTimerValue = 10.0f;
     public GameObject UFO;
     private float spawnTimer;
     // Start is called before the first frame update
    void Start()
    {
          spawnTimer = spawnTimerValue;
    }

    // Update is called once per frame
    void Update()
    {
          spawnTimer -= Time.deltaTime;
          if (spawnTimer <= 0) {
               //Debug.Log("Spawning Ufo...");
               spawnTimer = spawnTimerValue;
               Vector3 startingPosition = new Vector3(10.4f, 4.25f, 0);
               Instantiate(UFO, startingPosition, new Quaternion());
          }
    }
}
