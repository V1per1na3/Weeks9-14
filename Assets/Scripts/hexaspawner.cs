using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hexaspawner : MonoBehaviour
{
    public GameObject prefab;
    public Button buttontochange;
    public TextMeshProUGUI counts;
    int clicks = 0;
    // Start is called before the first frame update
    public void spawnhexa()
    {
        GameObject newhexa = Instantiate(prefab, Random.insideUnitCircle * 4, Quaternion.identity);
        hexascript hexagon = newhexa.GetComponent<hexascript>();
        buttontochange.onClick.AddListener(hexagon.changecolor);
        hexagon.onlick.AddListener(addtoclickcounter);
    }

    public void stoplistening()
    {
        buttontochange.onClick.RemoveAllListeners();
    }

    public void addtoclickcounter()
    {
        clicks++;
        counts.text = clicks.ToString();
    }

}
