using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColor : MonoBehaviour
{

    public Renderer rend;
    public LightSwitch ls;

    public Color lightColor;
    public Color darkColor;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ls.LightOn == true)
        {
            rend.material.color = lightColor;
        }
        else
        {
            rend.material.color = darkColor;
        }
    }
}
