using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int currentHealth = 5;

    public EnemyController theEC;
    public GameObject head, leftArm, rightArm;
    int  headShot = 0 , chest = 0, leftLeg = 0, rightLeg = 0, leftHand = 0, rightHand = 0 ;
    string readText = File.ReadAllText("WriteLines.txt");
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemy(int damageAmount , string bodyPoint)
    {
        currentHealth -= damageAmount;


        if (bodyPoint == "Headshot" )
        {

            headShot++;
        }
        if (bodyPoint == "Chest" )
        {
            
            chest++;
        }
        if (bodyPoint == "LeftLeg" )
        {
            
            leftLeg++;
        }
        if (bodyPoint == "RightLeg" )
        {
            
            rightLeg++;
        }
        if (bodyPoint == "LeftHand")
        {
            
            leftHand++;
        }
        if (bodyPoint == "RightHand" )
        {
            
            rightHand++;
        }


        if (theEC != null)
        {
            theEC.GetShot();
        }

        if(currentHealth <= 0)
        {
            Destroy(gameObject);

            AudioManager.instance.PlaySFX(2);
            string[] lines =
            {
            "HeadShot : "+headShot.ToString(), "Chest : "+ chest.ToString(), "LeftLeg : "+leftLeg.ToString(), "RightLeg : "+rightLeg.ToString(),"LeftHand : "+leftHand.ToString(),"RightHand : "+rightHand.ToString()
        };

            File.WriteAllLines("WriteLines.txt", lines);
        }
    }
}
