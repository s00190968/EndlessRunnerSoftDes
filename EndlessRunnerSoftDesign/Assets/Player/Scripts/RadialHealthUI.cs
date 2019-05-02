using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialHealthUI : MonoBehaviour
{
    //colors for healthbar stages
    public Color32 good;
    public Color32 medium;
    public Color32 bad;

    Image image;
    float imageFill;
    PlayerHealthSystem phs;

    // Use this for initialization
    void Start()
    {
        phs = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
        image = this.GetComponent<Image>();
        imageFill = phs.Health;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        imageFill = phs.Health;
        image.fillAmount = imageFill;

        //change colour according to how much life is left
        if (imageFill > .6f)//good
        {
            image.color = good;
        }
        else if (imageFill <= .6f)//medium
        {
            image.color = medium;
        }
        else if (imageFill <= .15f)//bad
        {
            image.color = bad;
        }
    }
}
