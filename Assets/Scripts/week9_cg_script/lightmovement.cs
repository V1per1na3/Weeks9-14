using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightmovement : MonoBehaviour
{
    public SpriteRenderer sr;
    public AnimationCurve cr;
    public float speed = 1f;
    [Range(0, 1)] public float t;
    public Vector2 originalsize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changecolor(bool ispoweron)
    {
        if (ispoweron)
        {
            sr.color = Random.ColorHSV();
        }
    }

    public void grow(bool ispoweron)
    {
        if (ispoweron)
        {
            Vector2 bling = transform.localScale;
            t += Time.deltaTime * speed;
            if (t > 1)
            {
                t = 0;
            }
            bling = originalsize * cr.Evaluate(t);
            transform.localScale = bling;
        }


    }
}
