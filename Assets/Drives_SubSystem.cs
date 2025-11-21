using UnityEngine;

public class Drives_SubSystem : SubSystem
{
    public AudioClip aud;
    public override void Use()
    {
        CooldownSet();
        if (OwnedByPlayer)
        {
            Player.me.Resources[1] -= resourceUsage[1];
            Player.me.speed += 50000;
            Player.me.renderer.PlaySFX(aud);
        }
        else
        {
            Enemy_AI.me.Resources[1] -= resourceUsage[1];
            Enemy_AI.me.speed += 50000;
            Enemy_AI.me.renderer.PlaySFX(aud);
        }
        Debug.Log("vroom");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health <= 0){
           if (OwnedByPlayer)
        {
            //Player.me.Resources[1] -= resourceUsage[1];
            Player.me.speed = 0;
            //Player.me.renderer.PlaySFX(aud);
        }
        else
        {
            //Enemy_AI.me.Resources[1] -= resourceUsage[1];
            Enemy_AI.me.speed = 0;
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
