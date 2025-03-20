using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class challenge1_grow : MonoBehaviour
{
    public AnimationCurve c;
    public float minsize = 0;
    public float maxsize =1;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getbig());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator getbig()
    {
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * maxsize * c.Evaluate(t);
            yield return null;
        }
        
    }
}
