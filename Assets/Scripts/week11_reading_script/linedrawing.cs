using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linedrawing : MonoBehaviour
{
    public LineRenderer lr;
    public List<Vector2> listofpoints;
    // Start is called before the first frame update
    void Start()
    {
        listofpoints = new List<Vector2>();
        lr.positionCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 newposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            listofpoints.Add(newposition);
            lr.positionCount++;
            lr.SetPosition(lr.positionCount-1,newposition);

        }

        if (Input.GetMouseButtonDown(1))
        {
            listofpoints = new List<Vector2>();
            lr.positionCount = 0;
        }
    }
}
