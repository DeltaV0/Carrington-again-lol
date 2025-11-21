using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pulse_Repeater_Subsystem : SubSystem
{
    public AudioClip aud;

    public override void Use()
    {
        CooldownSet();
        if (OwnedByPlayer)
        {
            Player.me.Resources[1] -= resourceUsage[1];
        }
        else
        {
            Enemy_AI.me.Resources[1] -= resourceUsage[1];
        }
        StartCoroutine(Fire());
        Debug.Log("BangBang");
        
    }

    IEnumerator Fire(){
        for(int i = 0; i < 5; i++){
            if(OwnedByPlayer){
        if(ID == 0)
            {
                Player.me.renderer.shootTurret1(OwnedByPlayer, 20, Player.me.TargetSelectedSystem, this, 2f, aud);
            } else if(ID == 1)
            {
                Player.me.renderer.shootTurret2(OwnedByPlayer, 20, Player.me.TargetSelectedSystem, this, 2f, aud);
            }
        } else
            {
        if(ID == 0)
            {
                Enemy_AI.me.renderer.shootTurret1(OwnedByPlayer, 20, Enemy_AI.me.TargetSelectedSystem, this, 2f, aud);
            } else if(ID == 1)
            {
                Enemy_AI.me.renderer.shootTurret2(OwnedByPlayer, 20, Enemy_AI.me.TargetSelectedSystem, this, 2f, aud);
            }
        
            }
            yield return new WaitForSeconds(0.1f);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
