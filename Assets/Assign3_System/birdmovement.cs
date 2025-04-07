using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class birdmovement : MonoBehaviour
{
    float speed = 1f;
    float t;
    float yoffset;
    public bool outside = false;
    public bridSpawnerScript spawner;
    // Start is called before the first frame update
    void Start()
    {
        //store initial y position (spawn y) at start
        yoffset = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        Vector2 pos = transform.position;
        pos.x -= speed*Time.deltaTime;
        t += speed * Time.deltaTime;
        //fly in a wavy pattern relative to the original spawn position y
        pos.y = yoffset + Mathf.PerlinNoise(t, 0);
        transform.position = pos;

        if(pos.x < -18f || pos.x >18f)
        {
            outside = true; 
        }
        else
        {
            outside = false;
        }
    }
}
