using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pointtomouse : MonoBehaviour
{
    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector2 dir = mouse - transform.position;
        transform.up = dir;
        Vector2 pos = transform.position;
        transform.position += speed*transform.up * Time.deltaTime;
    }
}
