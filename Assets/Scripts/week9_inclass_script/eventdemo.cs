using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class eventdemo : MonoBehaviour
{
    public RectTransform watermelon;
    public UnityEvent OnTimerhasfinished;
    public float timerlength = 3f;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > timerlength)
        {
            OnTimerhasfinished.Invoke();
            t = 0;
        }
    }

    public void mousejustenterimg()
    {
        watermelon.localScale = Vector3.one * 1.3f;
        Debug.Log("the mouse just entered");
    }

    public void mousejustexit()
    {
        watermelon.localScale = Vector3.one;
        Debug.Log("the mosue just exit");
    }
}
