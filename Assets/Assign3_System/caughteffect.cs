using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caughteffect : MonoBehaviour
{
    public ParticleSystem caughtP;
    // Start is called before the first frame update
    public void starteffect()
    {
        caughtP.Emit(20);
    }
}
