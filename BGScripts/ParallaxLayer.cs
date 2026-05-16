using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactorX = 0.3f;
    public float parallaxFactorY = 0.3f;

    Vector3 lastCamPos;

    public void Init(Vector3 camPos)
    {
        lastCamPos = camPos;
    }

    public void UpdateParallax(Vector3 camPos)
    {
        Vector3 delta = camPos - lastCamPos;

        transform.position += new Vector3(delta.x * parallaxFactorX, delta.y * parallaxFactorY, 0);

        lastCamPos = camPos;
    }
}
