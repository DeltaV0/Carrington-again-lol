using UnityEngine;

public class FlyWheelGenerator_SubSystem : SubSystem
{
    public AudioClip aud;
    public override void Use()
    {
        CooldownSet();
        if (OwnedByPlayer)
        {
            Player.me.Resources[0] -= 15;
            Player.me.Resources[1] += (int)(25 * Player.me.PowerGen);
            Player.me.renderer.PlaySFX(aud);
        }
        else
        {
            Enemy_AI.me.Resources[0] -= 15;
            Enemy_AI.me.Resources[1] += (int)(25 * Player.me.PowerGen);
            Enemy_AI.me.renderer.PlaySFX(aud);
        }
        //Player.me.PowerGen += 0.5f;
        Debug.Log("brrrt");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
