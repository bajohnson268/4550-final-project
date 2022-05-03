using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Minion : MonoBehaviour
{
    public string unit;
    public int health;
    public int attack;
    public string EnemyTeam;
    public GameObject projectileSpawnPoint;
    public GameObject projectile;
    Coroutine attacking;
    public AudioClip attackSound;
    AudioSource sound;

    Rigidbody rb;
    public bool alive = true;
    Animator anim;
    SphereCollider radius;
    public Transform movePositionTransform;
    NavMeshAgent navMeshAgent;
    public bool withinRange = false;
    public GameObject target;
    public int attackDelay;
    public Vector3 targetPosition;



    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        radius = gameObject.GetComponent<SphereCollider>();
        EnemyTeam = gameObject.name.Contains("BlueTeam") ? "RedTeam" : "BlueTeam";
        gameObject.tag = EnemyTeam.Equals("BlueTeam") ? "RedTeam" : "BlueTeam";
        navMeshAgent = GetComponent<NavMeshAgent>();
        int pFrom = gameObject.name.IndexOf("_");
        int pTo = gameObject.name.LastIndexOf("_");
        pFrom++;
        unit = gameObject.name.Substring(pFrom, pTo - pFrom);
        sound = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(target!=null)
            targetPosition = target.transform.position;
        if (health <= 0)
        {
            alive = false;
            anim.SetBool("Dead", true);
            GetComponent<SphereCollider>().enabled = false;
            navMeshAgent.destination = transform.position;
        }
        
        
        if (alive)
        {
            if (navMeshAgent.destination != transform.position && navMeshAgent.remainingDistance > 1f)
            {
                anim.SetBool("Walking", true);
            }
            else
                anim.SetBool("Walking", false);


            navMeshAgent.destination = (alive && movePositionTransform != null && !withinRange) ? movePositionTransform.position : transform.position;
            if (withinRange && target != null)
            {
                Vector3 lookDirection = Vector3.RotateTowards(transform.forward, target.transform.position - transform.position, 1.0f * Time.deltaTime, 0.0f);
                Debug.DrawRay(transform.position, lookDirection, Color.red);
                transform.LookAt(target.transform);
                //transform.rotation = Quaternion.LookRotation(lookDirection);
                if (attacking == null)
                {
                    
                    attacking = StartCoroutine(Attack());
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(EnemyTeam))
        {
            target = other.gameObject;
            withinRange = true;
        }
    }

   /* private void OnTriggerExit(Collider other)
    {
        target = null;
        withinRange = false;
    }*/


    IEnumerator Attack()
    {

        

        yield return new WaitForSeconds(attackDelay);

        if (target.GetComponent<Minion>().alive)
        {
            
            
            if (alive)
            {
                anim.Play("Attack");

                sound.PlayOneShot(attackSound);
                switch (unit)
                {
                    case string n when (n.Equals("Archer") || n.Equals("Mage")):
                        GameObject bullet = Instantiate(projectile, projectileSpawnPoint.transform.position, Quaternion.identity, projectileSpawnPoint.transform);
                        Vector3 direction = (target.transform.position - projectileSpawnPoint.transform.position).normalized * 4;
                        bullet.GetComponent<Rigidbody>().velocity = direction;
                        bullet.GetComponent<Projectile>().enemyTeam = EnemyTeam;
                        bullet.GetComponent<Projectile>().damage = attack;
                        Destroy(bullet, 5);

                        attacking = null;
                        break;

                    case string n when (n.Equals("SwordsMen") || n.Equals("TwoHandSwordsMen")):


                        target.GetComponent<Minion>().health -= attack;
                        target.GetComponent<Animator>().Play("Damaged");
                        

                        attacking = null;
                        break;
                }
            }

        }
        else
            target = null;
            
    }


}
