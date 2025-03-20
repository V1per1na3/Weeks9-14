using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpgrower : MonoBehaviour
{
    public AnimationCurve curve;
    public float minsize = 0;
    public float maxsize = 1;
    public float t;
    public bool startgrowing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startgrowing)
        {
            grow();
        }

    }

    public void sg()
    {
        startgrowing = true;
        t = 0;
    }

    public void grow()
    {
        if (t < 1)
        {
            t += Time.deltaTime;
        }
        else
        {
            startgrowing = false;
        }
        //transform.localScale = Vector3.one * maxsize * curve.Evaluate(t);//just animation curve
        //Vector3 start = new Vector3(minsize, minsize, maxsize);
        transform.localScale = Vector3.Lerp(Vector3.one * minsize, Vector3.one * maxsize, curve.Evaluate(t));//using lerp

    }
}
