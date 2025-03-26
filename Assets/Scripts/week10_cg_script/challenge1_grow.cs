using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class challenge1_grow : MonoBehaviour
{
    public AnimationCurve c;
    public float minsize = 0;
    public float maxsize =1;
    public float t;
    public Button atk;
    public bool startatk = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator getbig()
    {
        t = 0;
        while (t < 1)
        {
            atk.interactable = false;
            t += Time.deltaTime;
            transform.localScale = Vector3.one * maxsize * c.Evaluate(t);
            yield return null;
            atk.interactable = true;
        }   

    }

    

    public void hitbutton()
    {
        StartCoroutine(getbig());
    }
}
