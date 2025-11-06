using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class SubSystem : MonoBehaviour
{
    public string Name;

    public int[] level;

    public int Type;

    public int ID; //0 and 1 are weapons, 2 is shield, 3 is drives (default)

    public int health;

    public int maxHealth;

    public int[] resourceUsage;

    public int Cooldown;

    public int CooldownMax;
    public int CooldownDestroy;

    public bool OwnedByPlayer;

    //public int[] HealCooldown;

    void Start()
    {
        if (OwnedByPlayer)
        {
            Player.me.SubSystems[ID] = this;
        }
        else
        {
            Enemy_AI.me.SubSystems[ID] = this;
        }
    }

    public void Heal(int a)
    {
        if (health <= maxHealth)
            {
            health += a;
            }
    }

    void FixedUpdate()
    {
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
