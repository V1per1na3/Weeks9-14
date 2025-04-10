using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;

public class spawnhexa : MonoBehaviour
{
    public Slider sl;
    public GameObject prefabs;
    public List<GameObject> hexa;
    // Start is called before the first frame update
    void Start()
    {
        hexa = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnit()
    {
        Vector2 pos = new Vector2(Random.Range(10, -10), Random.Range(10, -10));
        GameObject newhexa = Instantiate(prefabs, pos, Quaternion.identity);
        hexascript growhexa = newhexa.GetComponent<hexascript>();
        //sl.onValueChanged.AddListener(growhexa.);
        hexa.Add(newhexa);
        
    }
}
