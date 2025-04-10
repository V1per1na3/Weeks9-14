using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class growhexa : MonoBehaviour
{
    public float t = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator grow(float t)
    {
        while (true)
        {
            transform.localScale = Vector3.one * t;
            yield return null;
        }
    }

    public void growit(float t)
    {
        StartCoroutine(grow(t));
    }
}
