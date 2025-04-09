using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Cinemachine.CinemachineBrain;

public class coinscript : MonoBehaviour
{
    public UnityEvent RainEvent;
    public Button rain;
    public TextMeshProUGUI coin;
    public float coinvalue = 5f;
    public float totalcaught = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //just to make sure it start with 0
        coin.text = coinvalue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        startritual();
    }
    public void addbasecoin()
    {
        //add 1 coin 
        coinvalue++;
        //update coin
        coin.text = coinvalue.ToString();
    }

    public void addcatch()
    {
        totalcaught++;
        //Debug.Log("caught" + totalcaught);
    }

    public void purchaserain()
    {
        RainEvent.Invoke();
        coinvalue -= 5;
        coin.text = coinvalue.ToString();
    }

    public void startritual()
    {
        if (coinvalue >= 5)
        {
            rain.interactable = true;
        }
        else
        {
            rain.interactable = false;
        }
    }

}
