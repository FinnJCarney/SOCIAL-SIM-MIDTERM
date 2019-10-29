using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareZone : MonoBehaviour
{

    public Color onColor;
    public Color offColor;
    public CircleCollider2D cc;
    public SpriteRenderer sr;

    public int timer;

    public GameObject Judas;

    // Start is called before the first frame update
    void Awake()
    {
        cc = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.color = offColor;
        cc.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        timer--;
        if(timer < 0)
        {
            TurnOff();
        }
    }

    public void TurnOn()
    {
        transform.parent = null;
        print("Turned On");
        timer = 30;
        sr.color = onColor;
        cc.enabled = true;
    }

    public void TurnOff()
    {
        print("Turn Off");
        sr.color = offColor;
        cc.enabled = false;
        transform.SetParent(Judas.transform);
        transform.position = Judas.transform.position;
    }
}
