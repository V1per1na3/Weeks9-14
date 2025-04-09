using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridSpawnerScript : MonoBehaviour
{
    //this script is to spawn birds using coroutine with countdown timer
    public GameObject prefabs;
    public List<GameObject> birds;
    public coinscript coinmanager;
    public caughteffect ce;
    public Coroutine birdspawning;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        birds = new List<GameObject>();
        //start the spawning using coroutine
        StartCoroutine(spawnit());
    }

    // Update is called once per frame
    void Update()
    {
        //check if any bird went out of map everyframe, if so destory them
        goaway();
    } 

    public IEnumerator spawnit()
    {
        //max bird in the scene will be 5
        //i use list count to keep track of how many bird i currently have
        while (birds.Count < 5)
        {
            //when there are less than 5 birds in the list
            //generate random position and I just happend to know this is the size of my map...
            pos = new Vector2(Random.Range(-15f, 15f), Random.Range(-9f, 9f));
            //instantiate birds at random position in the map
            GameObject newbirds = Instantiate(prefabs, pos, Quaternion.identity);
            //add it to list
            birds.Add(newbirds);
            //get the bird script so i have access to the catchbird event
            birdmovement bm = newbirds.GetComponent<birdmovement>();
            //add add coin function from coinmanager and particle effect script when catchbird event triggers
            bm.CatchBird.AddListener(coinmanager.addbasecoin);//add coin
            bm.CatchBird.AddListener(coinmanager.addcatch);//count how many player caught
            bm.CatchBird.AddListener(ce.starteffect);//play a particle effect to inform success catch
            //if player caught more than 3 birds in total
            if (coinmanager.totalcaught >= 3)
            {
                bm.alert();//bird start to be alert, fly faster when player is near by
            }
            //wait for 4 sec till next spawn
            yield return new WaitForSeconds(4);
        }
    }

    public void goaway()
    {
        //this function is to check if bird flies out of the map
        //and destory+remove them from the list to keep things clean
        for(int i= birds.Count-1; i >= 0; i--)
        {
            //loop thr the list
            //get component of each bird
            birdmovement bm = birds[i].GetComponent<birdmovement>();
            //register
            bm.spawner = this;
            //if its outside of map
            if (bm.outside)
            {
                //destroy and remove
                Destroy(birds[i]);
                birds.Remove(birds[i]);
            }
            
        }
    }


}
