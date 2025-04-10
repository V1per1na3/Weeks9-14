using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    //this script is to create a "fake" transform for the camera to follow.
    //so player can touch the edge of map and it will not be always in the center of camera when its about to hit map boundary

    public Transform realplayer;// this is the tranform of actual player
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 followpos = transform.position;
        //only update this follow item's transform.x when player.x is within certain range
        if(realplayer.transform.position.x > -8f && realplayer.transform.position.x < 8f)
        {
            followpos.x = realplayer.position.x;
        }
        //only update this follow item's transform.y when player.y is within certain range
        if (realplayer.transform.position.y > -6f && realplayer.transform.position.y < 6f)
        {
            followpos.y = realplayer.position.y;
        }
        transform.position = followpos;
    }
}
