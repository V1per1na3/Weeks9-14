using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbroco : MonoBehaviour
{
    public GameObject prefabs;
    public List<GameObject> broco;
    public CinemachineImpulseSource sc;
    // Start is called before the first frame update
    void Start()
    {
        broco = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject newbroco = Instantiate(prefabs, mousepos, Quaternion.identity);
            broco.Add(newbroco);
            sc.GenerateImpulse();//camera shake
        }

    }
}
