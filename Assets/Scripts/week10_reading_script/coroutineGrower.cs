using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutineGrower : MonoBehaviour
{
    public AnimationCurve curve;
    public float minsize = 0;
    public float maxsize = 1;
    public float t;
    public Transform apple;
    // Start is called before the first frame update

    // Update is called once per frame

    public void sg()
    {
        StartCoroutine(Grow());
    }

    public IEnumerator Grow()
    {
        apple.localScale = Vector3.zero;
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * maxsize * curve.Evaluate(t);
            yield return null;
        }

        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            apple.transform.localScale = Vector3.one * maxsize * curve.Evaluate(t);
            yield return null;
        }

    }
}
