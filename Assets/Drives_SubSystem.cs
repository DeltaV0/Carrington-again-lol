using UnityEngine;

public class Drives_SubSystem : SubSystem
{
    public override void Use()
    {
        CooldownSet();
        if (OwnedByPlayer)
        {
            Player.me.Resources[1] -= resourceUsage[1];
            Player.me.speed += 500;
        }
        else
        {
            Enemy_AI.me.Resources[1] -= resourceUsage[1];
            Enemy_AI.me.speed += 500;
        }
        Debug.Log("vroom");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
