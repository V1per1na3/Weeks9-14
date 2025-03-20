using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class trafficlightctrl : MonoBehaviour
{
    public trafficcarscript car;
    public SpriteRenderer trafficlight;
    SpriteRenderer sr;
    public UnityEvent Onleftclick;
    public UnityEvent OnRightclick;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (sr.bounds.Contains(mousepos))
            {
                Onleftclick.Invoke();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (sr.bounds.Contains(mousepos))
            {
                OnRightclick.Invoke();
            }
        }
    }

    public void go()
    {
        Debug.Log("go!");
        trafficlight.color = Color.green;
        car.Xspeed = 5f;
    }

    public void stop()
    {
        Debug.Log("stop!");
        trafficlight.color = Color.red;
        car.Xspeed = 0f;
    }
}
