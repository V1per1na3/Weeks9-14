using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class pumpkingrower : MonoBehaviour
{
    public bridSpawnerScript bs;
    public UnityEvent winevent;
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
        //winevent.AddListener(bs.stopspawn);
    }
    void Update()
    {
        Debug.Log(stage);
        checkstage();
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
    
    public void checkstage()
    {
        if (stage == 3)
        {
            winevent.Invoke();

        }
    }
}
