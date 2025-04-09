using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caughteffect : MonoBehaviour
{
    public ParticleSystem caughtP;
    public ParticleSystem rainP;
    // Start is called before the first frame update
    public void starteffect()
    {
        caughtP.Emit(20);
    }

    public void startrain()
    {
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
