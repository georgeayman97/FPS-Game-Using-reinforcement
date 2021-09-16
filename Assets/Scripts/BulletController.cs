using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed, lifeTime;

    public Rigidbody theRB;

    public GameObject impactEffect;

    public int damage = 1;

    public bool damageEnemy, damagePlayer;
     //int chest = 0, leftLeg = 0, rightLeg = 0, leftHand = 0, rightHand = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    // Update is called once per frame
    void Update()
    {
        theRB.velocity = transform.forward * moveSpeed;

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && damageEnemy)
        { 

             other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage, "Chest");


                if (other.gameObject.tag == "Headshot" && damageEnemy)
                {
                    other.transform.parent.GetComponent<EnemyHealthController>().DamageEnemy(damage * 2, "Headshot");
                    Debug.Log("Headshot");
                }
                    if (other.gameObject.tag == "Chest" && damageEnemy)
                {
                    other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage, "Chest");
                    Debug.Log("Chest");
                }
                if (other.gameObject.tag == "LeftLeg" && damageEnemy)
                {
                    other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage, "LeftLeg");
                    Debug.Log("LeftLeg");
                }
                if (other.gameObject.tag == "RightLeg" && damageEnemy)
                {
                    other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage, "RightLeg");
                    Debug.Log("RightLeg");
                }
                if (other.gameObject.tag == "LeftHand" && damageEnemy)
                {
                    other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage, "LeftHand");
                    Debug.Log("LeftHand");
                }
                if (other.gameObject.tag == "RightHand" && damageEnemy)
                {
                    other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage, "RightHand");
                    Debug.Log("RightHand");
                }
       }

        if (other.gameObject.tag == "Player" && damagePlayer)
        {
            PlayerHealthController.instance.DamagePlayer(damage);
        }
        

        Destroy(gameObject);
        Instantiate(impactEffect, transform.position + (transform.forward * (-moveSpeed * Time.deltaTime)), transform.rotation);
        
        

    }


}
