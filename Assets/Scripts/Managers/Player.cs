using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using DG.Tweening;

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

    public AudioSource Music;

    public bool Paused;

    private float fixedDeltaTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
        UnityEngine.Random.InitState((int)(System.DateTime.Now.Ticks * 10));
        me = this;
        PowerGen = 1f;
        this.fixedDeltaTime = Time.fixedDeltaTime;

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

    public void Update(){
        /*if (Input.GetKeyDown("space"))
        {
            if(Paused){
                Music.pitch = 1f;
                DOTween.timeScale = 1f;
                Time.timeScale = 1f;
                //Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
                Paused = false;
                
            } else {
                Music.pitch = 0f;
                DOTween.timeScale = 0f;
                Time.timeScale = 0f;
                //Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
                Paused = true;
            }
        }*/
    }

    public void MusicOff(){
        Music.DOPitch(0f, 5f);
    }

    public void CheckDeath()
    {
        if(health <= 0){
            foreach(SubSystem a in SubSystems)
            {
                a.health = 0;
            }
            MusicOff();
        renderer.Die();
        }
    }
}
