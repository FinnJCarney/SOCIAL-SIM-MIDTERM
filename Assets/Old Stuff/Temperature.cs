using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    public ACRemote AC;

    public float Temp;
    public float showTemp;
    public float tempChange;

    TextMesh Text;

    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<TextMesh>();
    }

    void Update()
    {
        showTemp = Mathf.Round(Temp * 10) / 10;
        Text.text = "" + showTemp + "°C";    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(AC.ACOn)
        {
            Temp -= tempChange;
        }

        else
        {
            Temp += tempChange;
        }
    }
}
