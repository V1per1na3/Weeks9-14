using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class lightspawnerscript : MonoBehaviour
{
    public lightswitchscript lt;
    public float timerlength = 3f;
    public float t;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnit();
    }

    public void spawnit()
    {
        t += Time.deltaTime;
        if (t > timerlength)
        {
            GameObject newlight = Instantiate(prefab, Random.insideUnitCircle * 4, Quaternion.identity);
            lightmovement ligh = newlight.GetComponent<lightmovement>();
            lt.turnonandoff.AddListener(ligh.changecolor);
            lt.turnonandoff.AddListener(ligh.grow);
            t = 0;
        }

    }

}
