using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Refractor_SubSystem : SubSystem
{
    public override void Use()
    {
        CooldownSet();
        if (OwnedByPlayer)
        {
            Player.me.Resources[1] -= resourceUsage[1];
            Enemy_AI.me.health -= Mathf.Clamp(100 - Block(OwnedByPlayer), 0, 1000);
            Player.me.TargetSelectedSystem.health -= Mathf.Clamp(100 - Block(OwnedByPlayer), 0, 1000);
        }
        else
        {
            Enemy_AI.me.Resources[1] -= resourceUsage[1];
            Player.me.health -= Mathf.Clamp(100 - Block(OwnedByPlayer), 0, 1000);
            Enemy_AI.me.TargetSelectedSystem.health -= Mathf.Clamp(100 - Block(OwnedByPlayer), 0, 1000);
        }
        Debug.Log("BangBang");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
