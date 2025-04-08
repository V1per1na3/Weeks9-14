using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class coinscript : MonoBehaviour
{
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

    public void addbasecoin()
    {
        //add 1 coin 
        coinvalue++;
        //update coin
        coin.text = coinvalue.ToString();
    }

    public void addbounus()
    {
        //add 2 coins
        coinvalue += 2;
        //update coin
        coin.text = coinvalue.ToString();
    }

    public void addcatch()
    {
        totalcaught++;
        Debug.Log("caught" + totalcaught);
    }

}
