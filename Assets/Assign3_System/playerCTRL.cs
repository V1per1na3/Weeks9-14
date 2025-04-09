using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class playerCTRL : MonoBehaviour
{
    //this script is for the player control//
    //player moves with WASD or arrowkeys and constrain within a fixed size of map//
    //player can press space bar to dash
    //theres cd for dash
    public birdmovement bm;
    SpriteRenderer sr;
    float speed = 5f;
    float dashdis = 1.5f;
    float directionx;
    float directiony;
    float dashcooldowntimer=0;
    float cooldowntime = 1f;
    bool candash=true;
    public Slider timerui;
    // Start is called before the first frame update
    void Start()
    {
        //register so bird prefab can get position of player
        bm.player = this;
        sr = GetComponent<SpriteRenderer>();
        //assign inital value to timer
        timerui.maxValue = cooldowntime;
        timerui.value = cooldowntime;
    }

    // Update is called once per frame
    void Update()
    {
        countdown();
        movement();
        checkedge();
    }

    void movement()
    {
        Vector2 pos = transform.position;
        //keyboard ctrl of player
        //get horizontal input
        directionx = Input.GetAxis("Horizontal");
        //get vertical input
        directiony = Input.GetAxis("Vertical");
        //flip sprite if dir is negative, in other words, facing left
        sr.flipX = directionx < 0;
        //move player base on input with fixed speed
        transform.position += transform.right * directionx * speed * Time.deltaTime;
        transform.position += transform.up * directiony * speed * Time.deltaTime;
        //player can dash away base on current dir when press space bar
        //only get the dir player is going without the magnitude
        Vector2 dir = new Vector2(directionx, directiony).normalized;
        //when player press space and candash
        if (Input.GetKeyDown(KeyCode.Space)&& candash)
        {
            //cannot dash anymore until timer reset this stage
            candash = false;
            //new position is player dir + dash distance
            pos += dir * dashdis;
            transform.position = pos;
            resettime();
        }

    }

    void countdown()
    {
        //when cannot dash
        if (!candash)
        {
            //countdown
            dashcooldowntimer -= Time.deltaTime;
            //assign value to slider
            timerui.value = dashcooldowntimer;
            //if timer goes to 0
            if (dashcooldowntimer <= 0)
            {
                candash = true;//can dash again
                timerui.value = cooldowntime;//reset silder

            }
        }
    }

    void resettime()
    {
        //reset the timer
        dashcooldowntimer = cooldowntime;
        timerui.maxValue = cooldowntime;
        timerui.value = cooldowntime;
        //Debug.Log(dashcooldowntimer);
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
