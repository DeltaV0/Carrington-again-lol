using UnityEngine;

public class SubSystem : MonoBehaviour
{
    public string Name;

    public int Type;

    public int ID; //0 and 1 are weapons, 2 is shield, 3 is drives (default)

    public int[] resourceUsage;

    public int Cooldown;

    public int CooldownMax;

    void Awake()
    {

//        Player.me.SubSystems.Insert(ID, this);
    }

    void FixedUpdate()
    {
        if (Cooldown > 0)
        {
            Cooldown--; 
        }
    }
    public virtual void Use()
    {
        //Cooldown = CooldownMax;
        Debug.Log("Used " + Name);
    }

    public void CooldownSet()
    {
        Cooldown = CooldownMax;
    }
}
