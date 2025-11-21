using UnityEngine;
using DG.Tweening;

public class PlayerRenderer : MonoBehaviour
{
    public Enemy_AI enemy;

    public Player player;

    public bool enemyuser;

    public Transform[] t;

    public Transform[] turrets;

    public Transform Camera;

    public GameObject[] pfs;

    public Transform shield;

    public AudioSource aud;

    public ParticleSystem DeathParts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Player.me;
        enemy = Enemy_AI.me;
        if (enemyuser)
        {
            enemy.rendererPos = transform;
            enemy.renderer = this;
        } else
        {
            player.rendererPos = transform;
            player.renderer = this;
        }
    }

    public void PlaySFX(AudioClip sfx){
        aud.pitch = Random.Range(0.9f, 1.1f);
        aud.PlayOneShot(sfx);
    }

    public void shootTurret1(bool p, int d, SubSystem sys1, SubSystem sys2, float s, AudioClip sfx)
    {
        aud.pitch = Random.Range(0.9f, 1.1f);
        aud.PlayOneShot(sfx);
        if(p){
            //magic numbers :(
        GameObject bullet = Instantiate(pfs[0], turrets[0].position, turrets[0].rotation);
        bullet.GetComponent<BulletGeneric>().target = enemy.rendererPos.position;
        bullet.GetComponent<BulletGeneric>().Damage = d; 
        bullet.GetComponent<BulletGeneric>().targetSystem = sys1;
        bullet.GetComponent<BulletGeneric>().shooterSystem = sys2;
        bullet.GetComponent<BulletGeneric>().PlayerUse = p;
        bullet.GetComponent<BulletGeneric>().speed = s;
        bullet.GetComponent<BulletGeneric>().Launch();
        } else
        {
           GameObject bullet = Instantiate(pfs[0], turrets[0].position, turrets[0].rotation);
            bullet.GetComponent<BulletGeneric>().target = player.rendererPos.position; 
            bullet.GetComponent<BulletGeneric>().Damage = d; 
            bullet.GetComponent<BulletGeneric>().targetSystem = sys1;
        bullet.GetComponent<BulletGeneric>().shooterSystem = sys2;
        bullet.GetComponent<BulletGeneric>().PlayerUse = p;
        bullet.GetComponent<BulletGeneric>().speed = s;
            bullet.GetComponent<BulletGeneric>().Launch();
        }
    }
    public void shootTurret2(bool p, int d, SubSystem sys1, SubSystem sys2, float s, AudioClip sfx)
    {
        aud.pitch = Random.Range(0.9f, 1.1f);
        aud.PlayOneShot(sfx);
        if(p){
        GameObject bullet = Instantiate(pfs[1], turrets[1].position, turrets[1].rotation);
        bullet.GetComponent<BulletGeneric>().target = enemy.rendererPos.position;
        bullet.GetComponent<BulletGeneric>().Damage = d; 
        bullet.GetComponent<BulletGeneric>().targetSystem = sys1;
        bullet.GetComponent<BulletGeneric>().shooterSystem = sys2;
        bullet.GetComponent<BulletGeneric>().PlayerUse = p;
        bullet.GetComponent<BulletGeneric>().speed = s;
        bullet.GetComponent<BulletGeneric>().Launch();
        } else
        {
           GameObject bullet = Instantiate(pfs[1], turrets[1].position, turrets[1].rotation);
            bullet.GetComponent<BulletGeneric>().target = player.rendererPos.position;  
            bullet.GetComponent<BulletGeneric>().Damage = d; 
            bullet.GetComponent<BulletGeneric>().targetSystem = sys1;
        bullet.GetComponent<BulletGeneric>().shooterSystem = sys2;
        bullet.GetComponent<BulletGeneric>().PlayerUse = p;
        bullet.GetComponent<BulletGeneric>().speed = s;
            bullet.GetComponent<BulletGeneric>().Launch();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shield.eulerAngles = new Vector3(shield.eulerAngles.x + 0.25f, shield.eulerAngles.y + 0.5f, shield.eulerAngles.z + 0.75f);
        if (enemyuser){
            shield.gameObject.SetActive(enemy.shieldAmount > 0);
        } else {
            shield.gameObject.SetActive(player.shieldAmount > 0);
        }
        
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

    public void Die()
    {
        transform.DOMove(transform.position - new Vector3(0, 100, 0),   10f).SetEase(Ease.InQuart);
        transform.DORotate(new Vector3(0, 0, Random.Range(-90, 90)), 10f).SetEase(Ease.InQuart);
        //DeathParts.Play();
    }
}
