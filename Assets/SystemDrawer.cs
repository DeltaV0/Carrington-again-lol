using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class SystemDrawer : MonoBehaviour
{
    public SubSystem system;

    public int ID;

    public RectTransform Bar;

    public TMP_Text[] texts;

    public GameObject Selector;

    public GameObject Targeted;

    public bool player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (player)
        {
            system = Player.me.SubSystems[ID];
        }
        else
        {
            system = Enemy_AI.me.SubSystems[ID];
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Targeted.SetActive(Player.me.TargetSelectedSystem == system || Player.me.PlayerSelectedSystem == system);
        Bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ((float)system.health / (float)system.maxHealth) * 100);
        texts[0].text = system.Name + "\nMK " + system.level[0] + "." + system.level[1];
        texts[1].text = system.health + "/" + system.maxHealth;
    }

    void OnMouseEnter(){
        Selector.SetActive(true);
    }
    void OnMouseExit(){
        Selector.SetActive(false);
    }
    void OnMouseDown(){
        if (player)
        {
            Player.me.PlayerSelectedSystem = system;
        }
        else
        {
            Player.me.TargetSelectedSystem = system;
        }
    }
}
