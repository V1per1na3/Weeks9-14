using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;

public class playermove : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;
    public Tilemap tm;
    public Tile grass;
    public Tile stone;
    public Transform prefabs;
    public List<Transform> waypoint;
    public AnimationCurve curve;
    public bool move = false;
    public bool isrunning = false;
    int currentwaypoint;
    int nextwaypoint;
    [Range(0, 1)]
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridpos = tm.WorldToCell(mousepos);
            Transform newwaypoint = Instantiate(prefabs, mousepos, Quaternion.identity);
            waypoint.Add(newwaypoint);

            if (tm.GetTile(gridpos) == stone)
            {
                move = true;
                Debug.Log("this is stone, move");
            }
            else 
            {
                move = false;
                Debug.Log("this is grass, ignore");
            }
        }
        if (waypoint.Count > 0 && move)
        {
            movment();
            anim.SetFloat("cornermovemnet", 1);

        }
        else
        {
            anim.SetFloat("cornermovemnet", 0);
        }



    }

    void movment()
    {
        Vector2 pos = transform.position;
        t += Time.deltaTime;
        if (t > 1)
        {
            t = 0;
            currentwaypoint = nextwaypoint;//update currentpoint and next point
            nextwaypoint = waypoint.Count-1;
        }
        pos = Vector2.Lerp(waypoint[currentwaypoint].position, waypoint[nextwaypoint].position, curve.Evaluate(t));
        transform.position = pos;
        

    }
}
