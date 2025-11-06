using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public static Player me;

    [Header("Misc Variables")]
    public int[] Resources; //steam, power, voltite

    public int Funding; //cash money

    public int[] Hull; //current health, max health

    public SubSystem[] SubSystems;

    public SubSystem PlayerSelectedSystem;

    public SubSystem TargetSelectedSystem;

    [Header("Changing Variables")]

    public float PowerGen;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        me = this;
        PowerGen = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //PowerGen = Mathf.Lerp(PowerGen, 1f, 0.0025f);
    }
}
