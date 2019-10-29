using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public static Controller Instance;
    public Flower flowerBase;
    public GameObject beeBase;
    
    
    // Use this for initialization

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start () {
		//Populate the world
        for (int i = 0; i < 10; i++)
        {
            Vector3 newSpawn = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
            Vector3 newSpawn2 = new Vector3(Random.Range(-2f, 2f), Random.Range(2f, 6f), Random.Range(-2f, 2f));
            Flower f = Instantiate(flowerBase, newSpawn, Quaternion.identity);
            GameObject b = Instantiate(beeBase, newSpawn2, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
