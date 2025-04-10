using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caughteffect : MonoBehaviour
{
    //this is the script that controls both rain and catch effect particles system
    public ParticleSystem caughtP;
    public ParticleSystem rainP;
    // Start is called before the first frame update
    public void starteffect()
    {
        //emit at one when player catches a bird
        caughtP.Emit(20);
    }

    public void startrain()
    {
        //play rain effect base on set duration
        if (rainP.isPlaying)
        {
            rainP.Stop();
        }
        else
        {
            rainP.Play();
        }
    }
}
