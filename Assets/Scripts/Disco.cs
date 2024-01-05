using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disco : MonoBehaviour
{
    public Light discoLight;

    private float value;

    // Update is called once per frame
    void Update()
    {
        value += .001f;
        discoLight.color = Color.HSVToRGB(value, 1, 1);
        if (value >= 1)
        {
            value = 0;
        }
    }
}
