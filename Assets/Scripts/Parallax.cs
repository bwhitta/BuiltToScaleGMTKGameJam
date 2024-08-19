using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    //public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = Camera.main.transform.position.x * (1 - parallaxEffect);
        float dist = Camera.main.transform.position.x * parallaxEffect;

        transform.position = new UnityEngine.Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}

