using UnityEngine;
using DG.Tweening;

public class BulletGeneric : MonoBehaviour
{

    public Vector3 target;

    public ParticleSystem part;

    public ParticleSystem spawnPart;

    //public Game part;

    public int Damage;

    public SubSystem targetSystem;

    public SubSystem shooterSystem;

    public bool PlayerUse;

    public float speed;

    public GameObject HitPF;

    public GameObject MissPf;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Launch(){
        //spawnPart.Play();
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
            if(Random.Range(0, 100) > targetSystem.Dodge(shooterSystem.OwnedByPlayer)){
            GameObject parts = Instantiate(HitPF, transform.position, transform.rotation);
            targetSystem.health -= Mathf.Clamp(Damage - shooterSystem.Block(shooterSystem.OwnedByPlayer), 0, 10000);
            Enemy_AI.me.health -= Mathf.Clamp(Damage - shooterSystem.Block(shooterSystem.OwnedByPlayer), 0, 10000);
            } else {
                GameObject parts = Instantiate(MissPf, transform.position, transform.rotation);
                transform.DOMove(target * 2f,   speed).SetEase(Ease.Linear);
            }
        } else {
            if(Random.Range(0, 100) > targetSystem.Dodge(shooterSystem.OwnedByPlayer)){
            GameObject parts = Instantiate(HitPF, transform.position, transform.rotation);
            targetSystem.health -= Mathf.Clamp(Damage - shooterSystem.Block(shooterSystem.OwnedByPlayer), 0, 10000);
            Player.me.health -= Mathf.Clamp(Damage - shooterSystem.Block(shooterSystem.OwnedByPlayer), 0, 10000);
            } else {
                GameObject parts = Instantiate(MissPf, transform.position, transform.rotation);
                transform.DOMove(target * 2f,   speed).SetEase(Ease.Linear);
            }
        }
        //Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
