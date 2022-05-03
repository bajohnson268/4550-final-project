using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public string enemyTeam;
    public int damage;
    public AudioClip hitSound;
    AudioSource sound;


    // Update is called once per frame
    void Start()
    {
        sound = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemyTeam) || collision.gameObject.CompareTag("Solid")) { 
            if (collision.gameObject.CompareTag(enemyTeam))
            {
                Debug.Log(collision.gameObject.name);
                collision.gameObject.GetComponent<Minion>().health -= damage;
                if (collision.gameObject.GetComponent<Minion>().health !=0)
                {
                    collision.gameObject.GetComponent<Animator>().Play("Damaged");
                }
                else
                    collision.gameObject.GetComponent<Animator>().SetBool("Dead", true);
                
            }
            sound.PlayOneShot(hitSound);
            Destroy(gameObject);
        }
    }



}
