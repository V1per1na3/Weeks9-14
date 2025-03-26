using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brocollictrl : MonoBehaviour
{
    public float speed = 5;
    public float rorationspeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -Input.GetAxisRaw("Horizontal") * rorationspeed * Time.deltaTime);
        transform.Translate(0,Input.GetAxisRaw("Vertical") * speed * Time.deltaTime,0);
    }
}
