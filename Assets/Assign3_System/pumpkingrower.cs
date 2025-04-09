using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class pumpkingrower : MonoBehaviour
{
    public playerCTRL pc;
    public coinscript cc;
    public AnimationCurve c1;
    public AnimationCurve c2;
    public AnimationCurve c3;
    public int stage = 0;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        if (stage < 3)
        {
            cc.RainEvent.AddListener(changestage);
            cc.RainEvent.AddListener(pc.resetpos);
        }
    }

    public void grow()
    {
        StartCoroutine(getbig());
    }
     public IEnumerator getbig()
    {
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            if (stage == 1)
            {
                transform.localScale = Vector3.one * c1.Evaluate(t);
            }
            else if(stage == 2)
            {
                transform.localScale = Vector3.one * c2.Evaluate(t);
            }
            else if(stage == 3)
            {
                transform.localScale = Vector3.one * c3.Evaluate(t);
            }
            yield return null;

        }
    }

    public void changestage()
    {
        stage++;
        Debug.Log(stage);
    }
    
}
