using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followmouse : MonoBehaviour
{
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 mouspos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = mouspos;
        transform.position = pos;
        //hit space bar to change color
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sr.color = Random.ColorHSV();
        }
    }
}
