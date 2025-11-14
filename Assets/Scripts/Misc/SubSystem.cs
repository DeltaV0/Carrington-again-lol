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

    void Awake()
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
        health = Mathf.Clamp(health, 0, maxHealth);
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

    public int Block(bool pl){
        if(pl){
            //if the player is using the card
            return (int)Mathf.Ceil((float)Enemy_AI.me.shieldAmount / 500f) * 15;
        } else {
            return (int)Mathf.Ceil((float)Player.me.shieldAmount / 500f) * 15;
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
