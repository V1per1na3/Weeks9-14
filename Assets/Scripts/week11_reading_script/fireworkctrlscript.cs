using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireworkctrlscript : MonoBehaviour
{
    public ParticleSystem firework;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //turn whole thing on and off//if turn off they will dissapear immediately
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firework.gameObject.SetActive(!firework.gameObject.activeInHierarchy);//turn on and off

        }
        //play and stop playing
        if (Input.GetMouseButtonDown(0))
        {
            if(firework.isPlaying == true)
            {
                firework.Stop();
            }
            else
            {
                firework.Play();
            }
        }
        //emit brust
        if (Input.GetMouseButtonDown(1))
        {
            firework.Emit(10);
        }
    }
}
