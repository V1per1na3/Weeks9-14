using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tilemapscript : MonoBehaviour
{
    public Tilemap tm;
    public Tile grass;
    public Tile snow;
    public CinemachineImpulseSource cis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            Vector2 mouspos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridpos = tm.WorldToCell(mouspos);
            Debug.Log(gridpos);

            if (tm.GetTile(gridpos) == grass)
            {
                Debug.Log("this is grass, turn me into snow");
                tm.SetTile(gridpos, snow);
                cis.GenerateImpulse(0.1f);
                
               
            }
            else
            {
                Debug.Log("this is snow, turn me into grass");
                tm.SetTile(gridpos, grass);
                cis.GenerateImpulse(0.1f);
            }
        }
    }
}
