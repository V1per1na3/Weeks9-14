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
        pg.winevent.AddListener(win);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator winning()
    {
        yield return new WaitForSeconds(1f);
        winpage.SetActive(true);
        restart.SetActive(true);
    }

    public void win()
    {
        wins=StartCoroutine(winning());
        StartCoroutine(stop());
    }

    public void replay()
    {
        cp.totalcaught = 0f;
        cp.coinvalue = 15;
        pumpkin.transform.localScale = Vector2.zero;
        pg.stage = 0;
        restart.SetActive(false);
        winpage.SetActive(false);
    }
    IEnumerator stop()
    {
        yield return null;
        if (wins != null)
        {
            StopCoroutine(wins);
        }
    }
}
