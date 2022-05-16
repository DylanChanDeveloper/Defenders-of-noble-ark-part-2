using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int Totalhitpoints = 4;

    [Tooltip("adds amount to totalHitPoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;

    int currentHitPoints = 0;// can serilize the currenthitpoints will allow us to see updates on the variable in the inspector.
  
    Enemy myEnemy;//creating a myEnemy variable to access enemy script.
    void OnEnable()// onEnable and on disable is called whenever a object is either enabled or disabled in the hierarchy. will reset the health if damage was taken.
    {
        currentHitPoints = Totalhitpoints;
    }

     void Start()
    {
        myEnemy = GetComponent<Enemy>();//gets the enemy script and stores it in the myEnemy value to access. We use GetComponent and not findObject of type because our enemy and enemyHealth script are both on the root of our object.
    }

    void OnParticleCollision(GameObject other)
    {//enable the collision module and make sure "send collision mesage" is ticked this will allow the particle collision to register.
        processHit();
    }
    //When OnParticleCollision is invoked from a script attached to a GameObject with a Collider, the GameObject parameter represents the ParticleSystem. The Collider receives at most one message per Particle System that collided with it in any given frame even when the Particle System struck the Collider with multiple particles in the current frame. To retrieve detailed information about all the collisions caused by the ParticleSystem, the ParticlePhysicsExtensions.GetCollisionEvents must be used to retrieve the array of ParticleSystem.CollisionEvent.
   // When OnParticleCollision is invoked from a script attached to a ParticleSystem, the GameObject parameter represents a GameObject with an attached Collider struck by the ParticleSystem.The ParticleSystem receives at most one message per Collider that is struck.As above, ParticlePhysicsExtensions.GetCollisionEvents must be used to retrieve all the collision incidents on the GameObject.
     void processHit()
    {
        currentHitPoints--;

        if(currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            // Destroy(gameObject); instead of destroying the object we disable it for our object pool to reuse

            myEnemy.Reward();//accessing and calling the reward method in our enemy script
            Totalhitpoints += difficultyRamp; //adds and reassigns the difficultyRamp to the totalhitPoints

        }
    }
}
