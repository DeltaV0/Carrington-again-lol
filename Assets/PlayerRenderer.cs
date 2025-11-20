using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    public Enemy_AI enemy;

    public Player player;

    public bool enemyuser;

    public Transform[] t;

    public Transform Camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Player.me;
        enemy = Enemy_AI.me;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Camera.localPosition = Random.insideUnitSphere * 0.025f;
        if (enemyuser)
        {
         for (int i = 0; i < t.Length; i++)
        {
            if (i % 2 == 0)
            {
                t[i].eulerAngles = new Vector3(0, 0, t[i].eulerAngles.z + 10f + (0.01f * enemy.speed));
            }
            else
            {
               t[i].eulerAngles = new Vector3(0, 0, t[i].eulerAngles.z - 10f - (0.01f * enemy.speed)); 
            }
        }   
        }else {
        for (int i = 0; i < t.Length; i++)
        {
            if (i % 2 == 0)
            {
                t[i].eulerAngles = new Vector3(0, 0, t[i].eulerAngles.z + 10f + (0.01f * player.speed));
            }
            else
            {
               t[i].eulerAngles = new Vector3(0, 0, t[i].eulerAngles.z - 10f - (0.01f * player.speed)); 
            }
        }
        }
    }
}
