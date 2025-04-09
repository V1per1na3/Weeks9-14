using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using static UnityEditor.PlayerSettings;

public class birdmovement : MonoBehaviour
{
    //this script is for bird movement, bird stay at initial spawn position untill player approach near it
    //when player is close enough, bird will start to fly away in random direction (left or right)
    int dir;
    SpriteRenderer sr;
    public playerCTRL player;
    public bool closeenough = false;
    float speed = 2.5f;
    float t;
    float yoffset;
    public bool outside = false;
    public bridSpawnerScript spawner;
    float distance;
    public float maxdis = 5f;
    public UnityEvent CatchBird;
    // Start is called before the first frame update
    void Start()
    {
        //pick a random dir at beginning
        //as max is exclusive, random.range only gives either 1 or 0 here,
        //0*2-1=-1, 1*2-1=1
        //so it randomize a random left or right direction (-1 or 1)
        dir = Random.Range(0, 2) * 2 - 1;
        //get spriterenderer so i can flip sprite base on dir
        sr = GetComponent<SpriteRenderer>();
        //store initial y position (spawn y) at start so bird fly around inital y using perlin noise
        yoffset = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //only start to move when player is close enough//
        //calculate the distance between the two
        distance = Vector2.Distance(transform.position, player.transform.position);
        //check if they are close enough
        
        if (distance< maxdis)
        {
            closeenough = true;//it will never need to return false so bird keeps flying away
        }
        //if close enough, bird start to move
        if (closeenough)
        {
            movement();
        }
        gotcaught();
        //Debug.Log(maxdis);
    }

    void movement()
    {
        //move function//
        Vector2 pos = transform.position;
        //fly to left or right with fixed speed
        pos.x += dir*speed*Time.deltaTime;
        //fly in a wavy pattern relative to the original spawn position y
        t += speed * Time.deltaTime;
        pos.y = yoffset + Mathf.PerlinNoise(t, 0);
        transform.position = pos;
        //flip sprite if dir is negative, in other words, facing left
        sr.flipX = dir < 0;
        ////////////////////////////////////////////////////////////////
        //check if bird flies out of map, 
        //this boolean will pass to spawner script to let it know when to destory it.
        //i'm just checking x here since bird only flies in left right dir.
        if (pos.x < -18f || pos.x >18f)
        {
            outside = true; 
        }
        else
        {
            outside = false;
        }
    }

    public void gotcaught()
    {
        //check if bird gotcaught
        //if the bird overlap with player
        if (sr.bounds.Contains(player.transform.position))
        {
            //bird got caught! trigger catchbird event
            CatchBird.Invoke();
            //destory this current gameobject
            Destroy(gameObject);
            //find it from the list in spawner script and remove it
            spawner.birds.Remove(gameObject);
        }
    }

    public void alert()
    {
        //this function get call in spawner script so each bird is alert after certain amount of bird got caught in total
        speed = 4.5f;//assign a faster speed
        //Debug.Log("activated");
    }

}
