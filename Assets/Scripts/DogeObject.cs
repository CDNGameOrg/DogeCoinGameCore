using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogeObject : MonoBehaviour {

    // Prefab for instantiating dogecoins
    public GameObject dogeCoinPrefab;

    // Doge speed
    public float speed = 1f;
    // Distance before Doge turns around
    public float leftAndRightEdge = 10f;
    // Chance for Doge to turn around
    public float chanceToChangeDirections = 0.1f;
    // DogeCoin drop rate
    public float secondsBetweenDogeCoinDrops = 1f;
    void Start()
    {
        Invoke("DropDogeCoin", 2f);
    }
    void DropDogeCoin()
    {
        GameObject dogeCoinOB = Instantiate<GameObject>(dogeCoinPrefab);
        dogeCoinOB.transform.position = transform.position;
        Invoke("DropDogeCoin", secondsBetweenDogeCoinDrops);

    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);//Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);//Move left
        }
    }
    void FixedUpdate()
    {
        // Changing Direction Randomly is now time-based because of FixedUpdate()
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;// Change direction
        }
    }
}