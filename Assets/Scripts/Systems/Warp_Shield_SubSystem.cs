using UnityEngine;

public class Warp_Shield_SubSystem : SubSystem
{
    public override void Use()
    {
        CooldownSet();
        if (OwnedByPlayer)
        {
            Player.me.Resources[1] -= resourceUsage[1];
            Player.me.shieldAmount += 500;
        }
        else
        {
            Enemy_AI.me.Resources[1] -= resourceUsage[1];
            Enemy_AI.me.shieldAmount += 500;
        }
        Debug.Log("Whirrt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
