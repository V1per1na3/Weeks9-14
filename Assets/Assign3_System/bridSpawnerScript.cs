using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridSpawnerScript : MonoBehaviour
{
    //this script is to spawn birds using coroutine with countdown timer
    public GameObject prefabs;
    public List<GameObject> birds;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        birds = new List<GameObject>();
        StartCoroutine(spawnit());
    }

    // Update is called once per frame
    void Update()
    {
        goaway();
    }

    public IEnumerator spawnit()
    {
        //max bird in the scene will be 5
        while (birds.Count < 5)
        {
            //generate random position and I just happend to know this is the size of my map...
            pos = new Vector2(Random.Range(-16f, 16f), Random.Range(-12f, 12f));
            //instantiate birds at random position in the map
            GameObject newbirds = Instantiate(prefabs, pos, Quaternion.identity);
            //add to list
            birds.Add(newbirds);
            //wait for 3 sec till next spawn
            yield return new WaitForSeconds(3);
        }
    }

    public void goaway()
    {
        for(int i= birds.Count-1; i >= 0; i--)
        {
            birdmovement bm = birds[i].GetComponent<birdmovement>();
            bm.spawner = this;
            if (bm.outside)
            {
                Destroy(birds[i]);
                birds.Remove(birds[i]);
            }
            
        }
    }
}
