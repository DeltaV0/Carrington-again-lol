using UnityEngine;

public class Pulse_Repeater_Subsystem : SubSystem
{
    public override void Use()
    {
        CooldownSet();
        Debug.Log("BangBang");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
