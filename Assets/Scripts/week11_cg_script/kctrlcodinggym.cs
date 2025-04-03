using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kctrlcodinggym : MonoBehaviour
{
    Animator anim;
    public bool jumped=false;
    public ParticleSystem dust;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jumpmove");
            jumped = true;
        }
        if (jumped)
        {
            anim.SetTrigger("fallmove");
            jumped = false;
        }
    }

    public void startdust()
    {
        dust.Emit(5);
    }
}
