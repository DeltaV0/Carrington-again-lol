using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GraphicsManager : MonoBehaviour
{
    public RectTransform cooldown;

    public RectTransform[] bars;

    public RectTransform[] Health;

    public TMP_Text textPE;

    public SystemDrawer[] drawers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //cooldown.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (1 - (Deck.me.DrawTimer[0] / Deck.me.DrawTimer[1]) * 490f) + 100f);
    }

    // Update is called once per frame
    void Update()
    {
        textPE.text = (Mathf.Round(Player.me.PowerGen * 100f) / 100f) + "x";
        bars[0].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Player.me.PowerGen * 100);
        bars[1].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Player.me.Resources[0] * 4.4f);
        bars[2].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Player.me.Resources[1] * 4.4f);

        Health[0].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ((float)Player.me.health / (float)Player.me.maxHealth) * 475);
        Health[1].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ((float)Enemy_AI.me.health / (float)Enemy_AI.me.maxHealth) * 475);

        cooldown.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1 * ((Mathf.Pow((float)Deck.me.DrawTimer[0] / Deck.me.DrawTimer[1], 2)) * 540f));
    }
}
