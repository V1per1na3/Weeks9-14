using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopsquare : MonoBehaviour
{
    public float t;
    // Start is called before the first frame update
    public void growLoop()
    {
        StartCoroutine(getBig());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator getBig()
    {
        t = 0;
        while (t < 1)//does all the loop in single frame
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * t;
            yield return null;
        }

        

    }
}
