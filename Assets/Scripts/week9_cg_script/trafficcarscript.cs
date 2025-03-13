using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficcarscript : MonoBehaviour
{
    public float Xspeed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += Time.deltaTime * Xspeed;//move in x automatically
                                         //check boundaries
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        if (screenpos.x < 0)
        {
            Vector2 fixpos = new Vector2(0, 0);
            Xspeed = Xspeed * -1;//reverse dir if hit boundary
        }
        if (screenpos.x > Screen.width)
        {
            Vector2 fixpos = new Vector2(Screen.width, 0);
            Xspeed = Xspeed * -1;//reverse dir if hit boundary
        }
        transform.position = pos;
    }

}

