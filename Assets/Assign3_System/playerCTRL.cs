using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCTRL : MonoBehaviour
{
    //this script is for the player control//
    //player moves with WASD or arrowkeys and constrain within a fixed size of map//
    public birdmovement bm;
    SpriteRenderer sr;
    float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        //register so bird prefab can get position of player
        bm.player = this;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        checkedge();
    }

    void movement()
    {
        //keyboard ctrl of player
        //get horizontal input
        float direction = Input.GetAxis("Horizontal");
        //get vertical input
        float direction2 = Input.GetAxis("Vertical");
        //flip sprite if dir is negative, in other words, facing left
        sr.flipX = direction < 0;
        //move player base on input with fixed speed
        transform.position += transform.right * direction * speed * Time.deltaTime;
        transform.position += transform.up * direction2 * speed * Time.deltaTime;
    }

    void checkedge()
    {
        //constrain player within the map
        Vector2 pos = transform.position;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        //check if player leaves screen left
        if (screenpos.x <= 0)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;//lock player x 
        }
        //check if player leaves screen right
        if (screenpos.x >= Screen.width)
        {
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;//lock player x
        }
        //check if player leaves screen top
        if (screenpos.y >= Screen.height)
        {
            pos.y = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;//lock player y
        }
        //check if player leaves screen bottom
        if (screenpos.y <= 0)
        {
            pos.y = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;//lock player y

        }

        transform.position = pos;

    }
}
