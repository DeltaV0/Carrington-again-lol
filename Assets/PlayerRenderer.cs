using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    public Player player;

    public Transform[] t;

    public Transform Camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Player.me;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Camera.localPosition = Random.insideUnitSphere * 0.025f;
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
