using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public bridSpawnerScript bs;
    public coinscript cp;
    public pumpkingrower pg;
    public GameObject winpage;
    public GameObject restart;
    public GameObject pumpkin;
    Coroutine wins;
    // Start is called before the first frame update
    void Start()
    {
        //call win 
        pg.winevent.AddListener(win);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator winning()
    {
        //using couroutine for showing the winning page and restart button because i want a bit delay
        //so player can watch the pumpkin fully grow to stage 3 before the win page pop out
        //wait for 2 sec
        yield return new WaitForSeconds(2f);
        //show win page
        winpage.SetActive(true);
        //show replay button
        restart.SetActive(true);
    }

    public void win()
    {
        //because i made winning coroutine to start with delay, I need to end it before I click the button
        //so button can work properly, otherwise it waits for the winning delay forever..?
        wins=StartCoroutine(winning());
        //this is super weird but it worked,,, start the coroutine that stops the coroutine...lmao
        StartCoroutine(stop());
    }

    public void replay()
    {
        //link to restart button, restart everything
        //reset total caught count
        cp.totalcaught = 0f;
        //reset coin to 0
        cp.coinvalue = 0f;
        cp.coin.text = cp.coinvalue.ToString();
        //reset size of pumpkin
        pumpkin.transform.localScale = Vector2.zero;
        //reset pumpkin growing stage
        pg.stage = 0;
        //hide itself(restart button)
        restart.SetActive(false);
        //hide winning page
        winpage.SetActive(false);
    }
    IEnumerator stop()
    {
        //stop the win coroutine
        yield return null;
        if (wins != null)
        {
            StopCoroutine(wins);
        }
    }
}
