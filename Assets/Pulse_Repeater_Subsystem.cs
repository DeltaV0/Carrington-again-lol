using UnityEngine;

public class Pulse_Repeater_Subsystem : SubSystem
{
    public override void Use()
    {
        CooldownSet();
        if (OwnedByPlayer)
        {
            Player.me.Resources[1] -= resourceUsage[1];
            Enemy_AI.me.health -= 100;
            Player.me.TargetSelectedSystem.health -= 100;
        }
        else
        {
            Enemy_AI.me.Resources[1] -= resourceUsage[1];
            Player.me.health -= 100;
            Enemy_AI.me.TargetSelectedSystem.health -= 100;
        }
        Debug.Log("BangBang");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
