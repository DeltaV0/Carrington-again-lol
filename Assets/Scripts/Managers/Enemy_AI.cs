using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public static Enemy_AI me;

    public Transform rendererPos;

    public int health;

    public int maxHealth;
    public SubSystem[] SubSystems;

    public int[] Resources;

    public SubSystem TargetSelectedSystem;
    public SubSystem HealSelectedSystem;

    public int timer;

    public int healtimer;

    public int shieldAmount;

    public int speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        me = this;
    }

    public SubSystem FindWeakestSystem(){
        SubSystem system = SubSystems[0];
        foreach(SubSystem sys in SubSystems){
            if((float)sys.health / (float)sys.maxHealth <= (float)system.health / (float)system.maxHealth){
                system = sys;
            }
        }
        return system;
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
        if (timer > 0)
        {
            timer--;
        }
        else
        {
            timer = Random.Range(25, 75);
            TargetSelectedSystem = Player.me.SubSystems[Random.Range(0, 4)];
            HealSelectedSystem = FindWeakestSystem();
            //for (int i = 0; i < EnemyDeck.me.Hand.Count; i++)
            //{
            if(EnemyDeck.me.Hand.Count > 0){
                Card sel = EnemyDeck.me.Hand[Random.Range(0, EnemyDeck.me.Hand.Count)];
                //work on this later
                if (sel.DisabledNoResources)
                {
                    sel.EnemyClick(1);
                } else {
                    sel.EnemyClick(0);
                }
            }
            //}
        }
    }
}
