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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        me = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
