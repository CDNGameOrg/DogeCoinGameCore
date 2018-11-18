using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogeCoin : MonoBehaviour {

    public static float belowFloor = -20f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < belowFloor)
        {
            Destroy(this.gameObject);
            // Grap reference to the ApplePicker component of Main Camera
            DogeGame dgScript = Camera.main.GetComponent<DogeGame>();
            // Call public AppleDestroyed() of dgScript
            dgScript.DogeCoinDestroyed();
        }

    }
}
