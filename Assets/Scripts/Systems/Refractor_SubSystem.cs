using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Refractor_SubSystem : SubSystem
{
    public override void Use()
    {
        if(OwnedByPlayer){
        if(ID == 0)
            {
                Player.me.renderer.shootTurret1(OwnedByPlayer);
            } else if(ID == 1)
            {
                Player.me.renderer.shootTurret2(OwnedByPlayer);
            }
        } else
            {
        if(ID == 0)
            {
                Enemy_AI.me.renderer.shootTurret1(OwnedByPlayer);
            } else if(ID == 1)
            {
                Enemy_AI.me.renderer.shootTurret2(OwnedByPlayer);
            }
        
            }


        CooldownSet();
        if (OwnedByPlayer)
        {
            Player.me.Resources[1] -= resourceUsage[1];
            if (Random.Range(0, 100) > Dodge(OwnedByPlayer))
            {
                Enemy_AI.me.health -= Mathf.Clamp(100 - Block(OwnedByPlayer), 0, 1000);
                Player.me.TargetSelectedSystem.health -= Mathf.Clamp(100 - Block(OwnedByPlayer), 0, 1000);
            } else
            {
                Debug.Log("miss!!");
            }
        }
        else
        {
            Enemy_AI.me.Resources[1] -= resourceUsage[1];
            if (Random.Range(0, 100) > Dodge(OwnedByPlayer))
            {
                Player.me.health -= Mathf.Clamp(100 - Block(OwnedByPlayer), 0, 1000);
                Enemy_AI.me.TargetSelectedSystem.health -= Mathf.Clamp(100 - Block(OwnedByPlayer), 0, 1000);
            }
            else
            {
                Debug.Log("Miss!!!!");
            }
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
