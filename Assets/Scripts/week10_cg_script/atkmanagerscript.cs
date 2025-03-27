using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class atkmanagerscript : MonoBehaviour
{
    public Button playerA;
    public Button playerB;
    public bool isAturn = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(taketurn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator taketurn()
    {
        while (true)
        {

            playerAturn();
            yield return null;

        }
    }

    public void playerAturn()
    {
        if (isAturn)
        {
            playerA.interactable = true;
            playerB.interactable = false;
        }
        isAturn = false;

        if (!isAturn)
        {
            playerA.interactable = false;
            playerB.interactable = true;
        }
        isAturn = true;

    }

}
