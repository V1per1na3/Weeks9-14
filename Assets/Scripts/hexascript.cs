using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class hexascript : MonoBehaviour
{
    public UnityEvent onlick;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void changecolor()
    {
        sr.color = Random.ColorHSV();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (sr.bounds.Contains(mousepos))
            {
                onlick.Invoke();
            }
        }
    }

    public void getbigger()
    {
        transform.localScale += Vector3.one * 0.1f;
    }

}
