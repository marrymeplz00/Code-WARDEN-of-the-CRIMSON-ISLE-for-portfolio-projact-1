using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    public Transform cam;
    public ParallaxLayer[] layers;

    void Start()
    {
        foreach (ParallaxLayer layer in layers)
        {
            layer.Init(cam.position);
        }
    }

    void LateUpdate()
    {
        Vector3 camPos = cam.position;

        foreach (ParallaxLayer layer in layers)
        {
            layer.UpdateParallax(camPos);
        }
    }
}
