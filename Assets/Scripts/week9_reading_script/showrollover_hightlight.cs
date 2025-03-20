using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class showrollover_hightlight : MonoBehaviour
{
    public Image image;
    public Sprite highlight;
    public Sprite normal;
    public TextMeshProUGUI rectext;

    public void mouseisover()
    {
        image.sprite = highlight;
        rectext.text = "blergh!";

    }

    public void mousenotover()
    {
        image.sprite = normal;
        rectext.text = "yum!";
    }

}
