using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentTerror : MonoBehaviour
{

    public float terror;
    public float anger;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.me.agents.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTerror(int i, int j)
    {
        terror = i;
        anger = j;
    }
}
