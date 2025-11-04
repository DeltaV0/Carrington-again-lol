using UnityEngine;

public class Player : MonoBehaviour
{
    public Player me;

    public int[] Resources;
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
