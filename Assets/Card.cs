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
    void Start()
    {
        Cooldown = MaxCooldown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Cooldown > 0){Cooldown--;}
        cd.fillAmount = 1 - (Cooldown / MaxCooldown);
    }

    public void OnMouseDown(){
        
    }
}
