using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conditionsquare : MonoBehaviour
{
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void growLarge()
    {
        if (t < 1)//if true, does this 1 step and update
        {
            t += Time.deltaTime;
        }

        transform.localScale = Vector3.one * t;
    }
}
