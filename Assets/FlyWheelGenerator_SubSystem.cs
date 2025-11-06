using UnityEngine;

public class FlyWheelGenerator_SubSystem : SubSystem
{
    public override void Use()
    {
        CooldownSet();
        Player.me.Resources[0] -= 15;
        Player.me.Resources[1] += (int)(25 * Player.me.PowerGen);
        //Player.me.PowerGen += 0.5f;
        Debug.Log("brrrt");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
