using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonTracker : MonoBehaviour
{

    public Vector3 pos;
    public bool hasRemote;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
    }
}
