using UnityEngine;
using DG.Tweening;

public class BulletGeneric : MonoBehaviour
{

    public Vector3 target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Invoke("kill", 5f);
        transform.DOMove(target, 5);
    }

    public void kill()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
