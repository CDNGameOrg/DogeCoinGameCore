using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogeGame : MonoBehaviour {

    public GameObject dogeCatchPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> dogeCatchList;

    // Use this for initialization
    void Start () {
        dogeCatchList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject dogeCatcherGO = Instantiate<GameObject>(dogeCatchPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            dogeCatcherGO.transform.position = pos;
            dogeCatchList.Add(dogeCatcherGO);
        }

    }

    public void DogeCoinDestroyed()
    {
        // Destroy all of the falling dogecoins
        GameObject[] dogeCoinArray = GameObject.FindGameObjectsWithTag("DogeCoin");
        foreach (GameObject tGO in dogeCoinArray)
        {
            Destroy(tGO);
        }
        // Destroy one of the catchers
        // Get the index of the last catcher in dogeCatchList
        int dogeCatchIndex = dogeCatchList.Count - 1;
        // Grab refrerence to Basket
        GameObject dogeCatcherGO = dogeCatchList[dogeCatchIndex];
        // Remove catcher and destroy object
        dogeCatchList.RemoveAt(dogeCatchIndex);
        Destroy(dogeCatcherGO);
        /*if (dogeCatchList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }*/
    }

    // Update is called once per frame
    void Update () {
		
	}
}
