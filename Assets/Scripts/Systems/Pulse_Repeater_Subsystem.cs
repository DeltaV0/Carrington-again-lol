using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pulse_Repeater_Subsystem : SubSystem
{
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
                Enemy_AI.me.health -= Mathf.Clamp(20 - Block(OwnedByPlayer), 0, 1000);
                Player.me.TargetSelectedSystem.health -= Mathf.Clamp(20 - Block(OwnedByPlayer), 0, 1000);
            } else {
                Player.me.health -= Mathf.Clamp(20 - Block(OwnedByPlayer), 0, 1000);
                Enemy_AI.me.TargetSelectedSystem.health -= Mathf.Clamp(20 - Block(OwnedByPlayer), 0, 1000);
            }
            yield return new WaitForSeconds(0.4f);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
