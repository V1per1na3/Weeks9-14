using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class pumpkingrower : MonoBehaviour
{
    //this script is use to grow the pumpkin as well as trigger the win event
    public bridSpawnerScript bs;
    public UnityEvent winevent;
    public playerCTRL pc;
    public coinscript cc;
    //3 different growing animation curve to take care of the size/growing anim
    public AnimationCurve c1;
    public AnimationCurve c2;
    public AnimationCurve c3;
    public int stage = 0;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        //before the pumpkin hit stage 3
        if (stage < 3)
        {
            //when rain, change the stage of pumpkin
            cc.RainEvent.AddListener(changestage);
            //reset player position beside the pumpkin
            cc.RainEvent.AddListener(pc.resetpos);
        }
    }
    void Update()
    {
        //Debug.Log(stage);
        //check if player gets to stage 3 everyframe
        checkstage();
    }

    public void grow()
    {
        //start growing function, linked to rain button
        //everytime player clicks the button, pumpkin grows
        StartCoroutine(getbig());
    }
     public IEnumerator getbig()
    {
        //use animation curve to grow the pumpkin to different sizes base on current stage
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            //check waht stage player currently is rn
            //and change the localscale base on specific curve
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
        //update stage, stage +1 whenever rains
        stage++;
        //Debug.Log(stage);
    }
    
    public void checkstage()
    {
        //check if stage is 3, if so, invoke the win event!
        if (stage == 3)
        {
            winevent.Invoke();

        }
    }
}
