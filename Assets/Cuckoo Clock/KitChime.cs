using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitChime : MonoBehaviour
{
    public void Chime(int h)
    {
        Debug.Log("Chiming !"+h+"o'clock");
    }

    public void Chimewithoutargument()
    {
        Debug.Log("Chiming !");
    }
}
