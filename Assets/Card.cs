using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;

public class Card : MonoBehaviour
{
    [Header("Misc settings")]
    public int handInd;
    public bool played;

    public int Cooldown;
    public int MaxCooldown;

    public Image cd;
    public Image cd2;
    public GameObject[] g;

    public bool Usable;

    public Vector3 target;

    [Header("Card Settings")]

    public bool system;

    public SubSystem systemToActivate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Cooldown = MaxCooldown;
        Set(true);
    }

    public void Set(bool set){
        g[0].SetActive(set);
        g[1].SetActive(set);
        g[2].SetActive(set);
        Usable = !set;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //fix this!
        //If revious hand ind is empty, move back
        target = Deck.me.CalcCurrHandPos(handInd);
        if (Cooldown > 0) { Cooldown--; }
        Set(!(Cooldown <= 0 && (!system || systemToActivate.Cooldown <= 0)));
        cd.fillAmount = (1f - ((float)Cooldown / (float)MaxCooldown));
        if (system)
        {
            cd2.fillAmount = (((float)systemToActivate.Cooldown / (float)systemToActivate.CooldownMax));
        }
        transform.position = Vector3.Lerp(transform.position, target, 0.1f);
    }

    public void UseCard()
    {
        if (system)
        {
            systemToActivate.Use();
        }
    }

    public void DiscardCard()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && Usable) //discard
        {
            Debug.Log("Right-clicked on " + gameObject.name);
            played = true;
            Deck.me.discard.Add (this);
            Deck.me.avalCardSlots [handInd] = true;
            transform.gameObject.SetActive (false);
            Deck.me.avalSlotCount++;
            Deck.me.Hand.Remove(this);
            // Add your desired right-click logic here
        }

        if (Input.GetMouseButtonDown(0) && Usable) //use
        {
            Debug.Log("Left-clicked on " + gameObject.name);
            played = true;
            Deck.me.discard.Add (this);
            Deck.me.avalCardSlots [handInd] = true;
            transform.gameObject.SetActive (false);
            Deck.me.avalSlotCount++;
            Deck.me.Hand.Remove(this);
            UseCard();
            // Add your desired right-click logic here
        }
    }
}
