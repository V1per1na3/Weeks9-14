using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class lightswitchscript : MonoBehaviour
{
    public lightspawnerscript c;
    public UnityEvent<bool> turnonandoff;
    public TextMeshProUGUI announce;
    public bool ispoweron = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ispoweron = !ispoweron;
            turnonandoff.Invoke(ispoweron);
            if (ispoweron)
            {
                announce.text = "on!";
            }
            else
            {
                announce.text = "off!";
            }
        }
    }
}
