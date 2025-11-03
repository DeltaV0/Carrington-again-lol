using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int handInd;
    public bool played;

    public int Cooldown;
    public int MaxCooldown;

    public Image cd;
    public GameObject[] g;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Activate();
    }

    public void Activate(){
        Cooldown = MaxCooldown;
        g[0].SetActive(true);
        g[1].SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Cooldown > 0){Cooldown--;} else {g[0].SetActive(false); g[1].SetActive(false);}
        cd.fillAmount = (1f - ((float)Cooldown / (float)MaxCooldown));
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && Cooldown <= 0) //discard
        {
            Debug.Log("Right-clicked on " + gameObject.name);
            played = true;
            Deck.me.discard.Add (this);
            Deck.me.avalCardSlots [handInd] = true;
            transform.gameObject.SetActive (false);
            Deck.me.avalSlotCount++;
            // Add your desired right-click logic here
        }

        if (Input.GetMouseButtonDown(0) && Cooldown <= 0) //use
        {
            Debug.Log("Left-clicked on " + gameObject.name);
            played = true;
            Deck.me.discard.Add (this);
            Deck.me.avalCardSlots [handInd] = true;
            transform.gameObject.SetActive (false);
            Deck.me.avalSlotCount++;
            // Add your desired right-click logic here
        }
    }
}
