using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarManager : MonoBehaviour
{
    public SpriteRenderer[] bars;
    public Color[] barColors;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bars.Length; i++)
        {
            barColors[i] = bars[i].color;
            bars[i].color = Color.clear;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void BarController(float x)
    {
        for (int i = 0; i < bars.Length; i++)
        {
            if((1 + i) * 5 < x)
            {
                TurnOn(i);
                print("Turning On " + i);
            }
            else
            {
                TurnOff(i);
                print("Turning Off " + i);
            }
        }
    }

    void TurnOn(int i)
    {
        bars[i].color = barColors[i];
    }

    void TurnOff(int i)
    {
        bars[i].color = Color.clear;
    }
}
