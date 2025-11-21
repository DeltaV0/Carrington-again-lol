using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Refractor_SubSystem : SubSystem
{
    public AudioClip aud;

    public override void Use()
    {
        if(OwnedByPlayer){
        if(ID == 0)
            {
                Player.me.renderer.shootTurret1(OwnedByPlayer, 100, Player.me.TargetSelectedSystem, this, 0.1f, aud);
            } else if(ID == 1)
            {
                Player.me.renderer.shootTurret2(OwnedByPlayer, 100 , Player.me.TargetSelectedSystem, this, 0.1f, aud);
            }
        } else
            {
        if(ID == 0)
            {
                Enemy_AI.me.renderer.shootTurret1(OwnedByPlayer, 100, Enemy_AI.me.TargetSelectedSystem, this, 0.1f, aud);
            } else if(ID == 1)
            {
                Enemy_AI.me.renderer.shootTurret2(OwnedByPlayer, 100, Enemy_AI.me.TargetSelectedSystem, this, 0.1f, aud);
            }
        
            }


        CooldownSet();
        if (OwnedByPlayer)
        {
            Player.me.Resources[1] -= resourceUsage[1];
        }
        else
        {
            Enemy_AI.me.Resources[1] -= resourceUsage[1];
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
