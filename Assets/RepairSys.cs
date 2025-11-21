using UnityEngine;

public class RepairSys : SubSystem
{
    public AudioClip aud;
    public override void Use()
    {
        CooldownSet();
        if (OwnedByPlayer)
        {
            Player.me.Resources[1] -= resourceUsage[1];
            //Enemy_AI.me.health -= Mathf.Clamp(100 - Block(OwnedByPlayer), 0, 1000);
            Player.me.PlayerSelectedSystem.Heal(75);
            Player.me.renderer.PlaySFX(aud);
        }
        else
        {
            Enemy_AI.me.Resources[1] -= resourceUsage[1];
            //Player.me.health -= Mathf.Clamp(100 - Block(OwnedByPlayer), 0, 1000);
            Enemy_AI.me.HealSelectedSystem.Heal(75);
            Enemy_AI.me.renderer.PlaySFX(aud);
        }
        Debug.Log("heal!! :3");
    }
}
