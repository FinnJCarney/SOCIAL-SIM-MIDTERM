using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareActivator : MonoBehaviour
{

    BoxCollider2D bc;
    ScareZone sz;
    Vector2 mousePos;
    float hBW; //Half Box Width

    public void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        sz = GetComponentInChildren<ScareZone>();
        hBW = bc.size.x / 2;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sz.TurnOn();
        }
    }
}
