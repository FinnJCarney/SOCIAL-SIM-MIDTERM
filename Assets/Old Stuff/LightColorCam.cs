using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColorCam : MonoBehaviour
{

    public Color colorL;
    public Color colorO;

    public Camera cam;

    public LightSwitch ls;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ls.LightOn == true)
        {
            cam.backgroundColor = colorL;
        }
        else
        {
            cam.backgroundColor = colorO;
        }
    }
}
