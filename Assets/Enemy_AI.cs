using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public static Enemy_AI me;

    public int health;

    public int maxHealth;
    public SubSystem[] SubSystems;

    public int[] Resources;

    public SubSystem TargetSelectedSystem;
    public SubSystem HealSelectedSystem;

    public int timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        me = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer--;
        }
        else
        {
            timer = 25;
            for (int i = 0; i < EnemyDeck.me.Hand.Count; i++)
            {
                Card sel = EnemyDeck.me.Hand[i];
                //work on this later
                if (sel.ID)
                {
                    if (Resources[0] < 15 || Resources[1] < 15)
                    {
                        if()
                        EnemyDeck.me.Hand[i].EnemyClick(1);
                    } else
                }
            }
        }
    }
}
