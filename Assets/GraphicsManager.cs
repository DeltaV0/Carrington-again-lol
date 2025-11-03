using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GraphicsManager : MonoBehaviour
{
    public RectTransform cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //cooldown.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (1 - (Deck.me.DrawTimer[0] / Deck.me.DrawTimer[1]) * 490f) + 100f);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1 * ((Mathf.Pow((float)Deck.me.DrawTimer[0] / Deck.me.DrawTimer[1], 2)) * 540f));
    }
}
