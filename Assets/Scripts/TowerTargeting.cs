using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTargeting : MonoBehaviour
{    
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    Transform target;
    [SerializeField] float maxRange = 15f;

    void Update()
    {
        FindClosestTarget();//in update we will always check to see what the closest target is and perform all these calculations.
        AimWeapon();
    }

   void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();//finds the gameOnjects with the enemy script attached to it and assigns it to the enemies array.
        Transform closestTarget = null;//allows us to know which enemy is the closest, set to null because we wont have found one right at the start.
        float maxDistance = Mathf.Infinity;// maxDistance will be used to hold the current furthest distance of the enemy (Mathf.Infinity). We use this to find if the newest enemy is closer than the last.

        foreach(Enemy myEnemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, myEnemy.transform.position);// Vector3.Distance returns the distance between a and b, it will find the distance of our current position and tge position of the enemy. Then store it inside targetDistance.

            if(targetDistance < maxDistance)// we are comparing if the target distance is less than the max distance.
            {
                closestTarget = myEnemy.transform;//are closest target is going to be the enemy.transform
                maxDistance = targetDistance;//reduces the max distance to the current distance of the enemy.So when we check the next enemy we can see if that one is closer or further away.
            }
        }

        target = closestTarget;// are new target is going to equal to the closest target we found.
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);//checks if are enemy is in range of our tower. This is done by this distance check.
                                                                                     //we get our current position and the target.position of our enemy
        weapon.LookAt(target);

      if(targetDistance < maxRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        
        var myEmissions = projectileParticles.emission; // we get the emissions so we can set if the particle is firing or not

        myEmissions.enabled = isActive; // sets are emission module to what ever we passed in.
    }
}
