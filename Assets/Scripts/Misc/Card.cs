using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class Card : MonoBehaviour
{
    public TMP_Text textplaceholder;
    public bool playerCard;
    
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

    public int systemID;
    public SubSystem systemToActivate;

    public bool DisabledNoResources;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (playerCard)
        {
            systemToActivate = Player.me.SubSystems[systemID];
            Set(true);
            textplaceholder.text = systemToActivate.Name;
        }
        else
        {
            systemToActivate = Enemy_AI.me.SubSystems[systemID];
        }
        Cooldown = MaxCooldown;
        
        
    }

    public void Set(bool set){
        if(playerCard){
        g[0].SetActive(set);
        g[1].SetActive(set);
        g[2].SetActive(set);
        Usable = !set && !DisabledNoResources;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerCard)
        {
            if (system)
            {
                DisabledNoResources = !(Player.me.Resources[0] >= systemToActivate.resourceUsage[0] && Player.me.Resources[1] >= systemToActivate.resourceUsage[1] && Player.me.Resources[2] >= systemToActivate.resourceUsage[2]);
            }
            g[3].SetActive(DisabledNoResources);
            //fix this!
            //If revious hand ind is empty, move back
            //target = Deck.me.CalcCurrHandPos(handInd);
            if (Cooldown > 0) { Cooldown--; }
            Set(!(Cooldown <= 0 && (!system || systemToActivate.Cooldown <= 0)));
            cd.fillAmount = (1f - ((float)Cooldown / (float)MaxCooldown));
            if (system)
            {
                cd2.fillAmount = (((float)systemToActivate.Cooldown / (float)systemToActivate.CooldownMax));
            }
            transform.position = Vector3.Lerp(transform.position, target, 0.1f);
        }
        else
        {
            if (system)
            {
                DisabledNoResources = !(Enemy_AI.me.Resources[0] >= systemToActivate.resourceUsage[0] && Enemy_AI.me.Resources[1] >= systemToActivate.resourceUsage[1] && Enemy_AI.me.Resources[2] >= systemToActivate.resourceUsage[2]);
            }
            if (Cooldown > 0) { Cooldown--; }
            Usable = (Cooldown <= 0 && (!system || systemToActivate.Cooldown <= 0)) && !DisabledNoResources;
        }
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

    public void EnemyClick(int a)
    {
        if (a == 1) //discard
        {
            Debug.Log("Right-clicked on " + gameObject.name);
            played = true;
            EnemyDeck.me.discard.Add (this);
            EnemyDeck.me.avalCardSlots [handInd] = true;
            
            EnemyDeck.me.avalSlotCount++;
            EnemyDeck.me.Hand.Remove(this);
            Cooldown = MaxCooldown;
            // Add your desired right-click logic here
            Enemy_AI.me.Resources[0] += 10;
            transform.gameObject.SetActive (false);
        }

        if (a == 0 && Usable) //use
        {
            Debug.Log("Left-clicked on " + gameObject.name);
            played = true;
            EnemyDeck.me.discard.Add (this);
            EnemyDeck.me.avalCardSlots [handInd] = true;
            EnemyDeck.me.avalSlotCount++;
            EnemyDeck.me.Hand.Remove(this);
            Cooldown = MaxCooldown;
            UseCard();
            transform.gameObject.SetActive (false);
            
            // Add your desired right-click logic here
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1)) //discard
        {
            Debug.Log("Right-clicked on " + gameObject.name);
            played = true;
            Deck.me.discard.Add (this);
            Deck.me.avalCardSlots [handInd] = true;
            
            Deck.me.avalSlotCount++;
            Deck.me.Hand.Remove(this);
            Cooldown = MaxCooldown;
            // Add your desired right-click logic here
            Player.me.Resources[0] += 10;
            transform.gameObject.SetActive (false);
        }

        if (Input.GetMouseButtonDown(0) && Usable) //use
        {
            Debug.Log("Left-clicked on " + gameObject.name);
            played = true;
            Deck.me.discard.Add (this);
            Deck.me.avalCardSlots [handInd] = true;
            Deck.me.avalSlotCount++;
            Deck.me.Hand.Remove(this);
            Cooldown = MaxCooldown;
            UseCard();
            transform.gameObject.SetActive (false);
            
            // Add your desired right-click logic here
        }
    }
}
