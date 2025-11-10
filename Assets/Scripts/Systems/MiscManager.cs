using UnityEngine;

public class MiscManager : MonoBehaviour
{

    public Enemy_AI[] enemy;

    public SubSystem selected;

    public static MiscManager me;
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
