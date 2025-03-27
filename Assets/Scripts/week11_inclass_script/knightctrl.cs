using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class knightctrl : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;
    public float speed = 2f;
    public bool canrun = true;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        sr.flipX = direction < 0;
        anim.SetFloat("cornermovemnet",Mathf.Abs(direction));

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("atkmove");
            canrun = false;
        }
        if (canrun == true)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }

    }

    public void atkend()
    {
        Debug.Log("ends!");
        canrun = true;
    }
}
