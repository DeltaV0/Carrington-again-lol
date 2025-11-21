using UnityEngine;

public class Warp_Shield_SubSystem : SubSystem
{
    public AudioClip aud;
    public override void Use()
    {
        CooldownSet();
        if (OwnedByPlayer)
        {
            Player.me.Resources[1] -= resourceUsage[1];
            Player.me.shieldAmount += 500;
            Player.me.renderer.PlaySFX(aud);
        }
        else
        {
            Enemy_AI.me.Resources[1] -= resourceUsage[1];
            Enemy_AI.me.shieldAmount += 500;
            Enemy_AI.me.renderer.PlaySFX(aud);
        }
        Debug.Log("Whirrt");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health <= 0){
           if (OwnedByPlayer)
        {
            //Player.me.Resources[1] -= resourceUsage[1];
            Player.me.shieldAmount = 0;
            //Player.me.renderer.PlaySFX(aud);
        }
        else
        {
            //Enemy_AI.me.Resources[1] -= resourceUsage[1];
            Enemy_AI.me.shieldAmount = 0;
            //Enemy_AI.me.renderer.PlaySFX(aud);
        } 
        }
        if (Cooldown > 0 && health > 0)
        {
            Cooldown--;
        }

        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0)
        {
            Cooldown = CooldownDestroy;
        }
    }
}
