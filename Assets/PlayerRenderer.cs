using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    public Enemy_AI enemy;

    public Player player;

    public bool enemyuser;

    public Transform[] t;

    public Transform[] turrets;

    public Transform Camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Player.me;
        enemy = Enemy_AI.me;
        if (enemyuser)
        {
            enemy.rendererPos = transform;
        } else
        {
            player.rendererPos = transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Camera.localPosition = Random.insideUnitSphere * 0.025f;
        if (enemyuser)
        {
            for(int i = 0; i < turrets.Length; i++)
            {
               Vector3 diff = player.rendererPos.position - turrets[i].position;
                diff.Normalize();  
                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                turrets[i].rotation = Quaternion.Euler(0f, 0f, Mathf.LerpAngle(turrets[i].eulerAngles.z,rot_z - 90, 0.01f));
            }
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
            for(int i = 0; i < turrets.Length; i++)
            {
                Vector3 diff = enemy.rendererPos.position - turrets[i].position;
                diff.Normalize();  
                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                turrets[i].rotation = Quaternion.Euler(0f, 0f, Mathf.LerpAngle(turrets[i].eulerAngles.z,rot_z - 90, 0.01f));
                //turrets[i].LookAt(enemy.rendererPos,Vector3.down);
            }
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
