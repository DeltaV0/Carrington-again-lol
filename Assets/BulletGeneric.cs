using UnityEngine;
using DG.Tweening;

public class BulletGeneric : MonoBehaviour
{

    public Vector3 target;

    public ParticleSystem part;

    public int Damage;

    public SubSystem targetSystem;

    public SubSystem shooterSystem;

    public bool PlayerUse;

    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Launch(){
        part.Play();
        target.y += Random.Range(-2f, 2f);
        Invoke("Hit", speed);
        transform.DOMove(target,   speed).SetEase(Ease.Linear);
    }
    void Awake()
    {
        
    }

    public void Hit()
    {
        
        if(PlayerUse){
            if(Random.Range(0, 100) > targetSystem.Dodge(targetSystem.OwnedByPlayer)){
            targetSystem.health -= Mathf.Clamp(Damage - shooterSystem.Block(shooterSystem.OwnedByPlayer), 0, 10000);
            Enemy_AI.me.health -= Mathf.Clamp(Damage - shooterSystem.Block(shooterSystem.OwnedByPlayer), 0, 10000);
            }
        } else {
            if(Random.Range(0, 100) > targetSystem.Dodge(targetSystem.OwnedByPlayer)){
            targetSystem.health -= Mathf.Clamp(Damage - shooterSystem.Block(shooterSystem.OwnedByPlayer), 0, 10000);
            Player.me.health -= Mathf.Clamp(Damage - shooterSystem.Block(shooterSystem.OwnedByPlayer), 0, 10000);
            }
        }
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
