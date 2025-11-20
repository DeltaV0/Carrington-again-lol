using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public static Player me;

    [Header("Misc Variables")]

    public Transform rendererPos;

    public PlayerRenderer renderer;
    public int[] Resources; //steam, power, voltite

    public int Funding; //cash money

    //public int[] Hull; //current health, max health

    public SubSystem[] SubSystems;

    public SubSystem PlayerSelectedSystem;

    public SubSystem TargetSelectedSystem;

    public int health;

    public int maxHealth;

    [Header("Changing Variables")]

    public float PowerGen;

    public int[] CooldownHeal;

    public int shieldAmount;

    public int speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Random.InitState(0);
        me = this;
        PowerGen = 1f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shieldAmount > 0)
        {
            shieldAmount--;
        }
        
        if(speed > 0){
            speed--;
        }
        
    }
}
