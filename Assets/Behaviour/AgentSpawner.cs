using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{

    public GameObject agent;

    public int spawnTimer;
    public int spawnAlarm;

    public bool isTop;

    // Start is called before the first frame update
    void Start()
    {
        spawnAlarm = Random.Range(45, 180);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        if (GameManager.me.GameOn == true)
        {
            spawnTimer++;
        }
        if (spawnTimer >= spawnAlarm)
        {
            Instantiate(agent, new Vector2(transform.position.x + (Random.Range(-0.75f, 0.75f)), transform.position.y), Quaternion.identity);
            spawnTimer = 0;
            spawnAlarm = Random.Range(45, 180);
        }
    }
}
