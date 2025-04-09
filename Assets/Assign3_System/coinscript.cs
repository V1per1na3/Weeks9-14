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
    //this is the script that take cares of coins caculation and rain event
    public UnityEvent RainEvent;
    public Button rain;
    public TextMeshProUGUI coin;
    public float coinvalue = 0f;
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
        //check if player can start the rain ritual every frame
        startritual();
    }
    public void addbasecoin()
    {
        //for catch bird event, call this function when catchbird event tirggers
        //add 1 coin 
        coinvalue++;
        //update coin
        coin.text = coinvalue.ToString();
    }

    public void addcatch()
    {
        //for catch bird event, call this function when catchbird event tirggers
        //count how many bird player caught
        totalcaught++;
        //Debug.Log("caught" + totalcaught);
    }

    public void purchaserain()
    {
        //for rain event, I link this to the start rain button
        //whenever i click the button, rain event triggers
        RainEvent.Invoke();
        //cost 5 coin to click this button
        coinvalue -= 5;
        coin.text = coinvalue.ToString();
    }

    public void startritual()
    {
        //if player has more than 5 coins
        if (coinvalue >= 5)
        {
            //you may click the button
            rain.interactable = true;
        }
        else
        {
            //otherwise you cannot click the button
            rain.interactable = false;
        }
    }

}
