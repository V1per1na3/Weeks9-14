using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pulse : MonoBehaviour
{
    public float speed = 2f;
    public float t;
    public AnimationCurve cruve;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += Time.deltaTime*speed;
        Vector2 screenpos = Camera.main.WorldToScreenPoint(pos);
        if (screenpos.x >= Screen.width)
        {
            pos.x = -10;
        }

        pos.y = cruve.Evaluate(pos.x);
        transform.position = pos;
    }
}
