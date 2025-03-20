using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointereventscript : MonoBehaviour
{
    public Image img;
    public Sprite cake;
    public Sprite milk;
    public GameObject prefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changetocake()
    {
        img.sprite = cake;
    }

    public void changetomilk()
    {
        img.sprite = milk;
    }

    public void spawnmilkshake()
    {
        GameObject newmilkshake = Instantiate(prefabs, Random.insideUnitCircle * 4, Quaternion.identity);
    }
}
