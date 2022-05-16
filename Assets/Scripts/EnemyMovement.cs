using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]//we require the Enemy component, when we use requireComponent and attach this script to a object it will automatically bring in the "Enemy" script. Remember it wont try to bring in the script if it already exsists e.g. if you manually placed it in before writting this code.
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float mySpeed = 1f;
    [SerializeField] List<Waypoint> myPathWay = new List<Waypoint>();//List syntax is we declare the list with sheverons, 
                                                                     //then inside the cheverons we specifiy the thing its goint to be storing in this case the waypoint script,
                                                                     //we finally initalize the list with new List<Waypoints>, e.g. we initalize pathway to a new list of waypoints

    Enemy myEnemy;//creating a myEnemy variable to access enemy script.

    public void Start()
    {
        myEnemy = GetComponent<Enemy>();//gets the enemy script and stores it in the myEnemy value to access. We use GetComponent and not findObject of type because our enemy and enemyHealth script are both on the root of our object.
    }

    void OnEnable()// onEnable and on disable is called whenever a object is either enabled or disabled in the hierarchy.
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPoint());//using a co routine so for loop will wait for x amount of seconds before executing. To prevent object from teleporting from point A to B instantly
    //1.we are going to start our co-routine here
    }

    void FindPath()
    {
        myPathWay.Clear();//when we find a path, we're going to clear the existing one and then add a new one. To prevent the path adding existing paths and getting longer.

        GameObject myParent = GameObject.FindGameObjectWithTag("Pathway");//finds the object with tag Pathway and places it in the myParent GameObject variable.

        foreach(Transform myChild in myParent.transform)//what this foreach does now is, find that myParent object that we've tagged with the "Pathway" and loops through all its children in order.
        {
            Waypoint waypoint = myChild.GetComponent<Waypoint>();//were going to look for a waypoint called waypoint and its going to equal to myChild.GetComponent<Waypoint>()

            if (waypoint != null)//guard statement if the waypoint is not null 
            {
                myPathWay.Add(waypoint);//then we want to add are waypoint to the path.
            }     
            //these changes will ensure are waypoint is in the correct order and that our path only exists of waypoints and nothing that accidentally slips into that folder later on.
        }

    }

   public void ReturnToStart()
    {    
        transform.position = myPathWay[0].transform.position;//gets the first elements position and stores it in transform.position
    }

    void finishPoint()
    {
        myEnemy.stealGold();//access the enemy script and the steals gold.
        gameObject.SetActive(false);//were turning the gameobject off, rather then destroy it because it will be free for the pool to reuse again later.    
    }

    IEnumerator FollowPoint()
    {
        foreach (Waypoint myWaypoint in myPathWay)//loops through every element in the list 2.co routine starts the for loop
        {
            //3.sets up the start and end position we want to move too
            Vector3 startPos = transform.position;
            Vector3 endPos = myWaypoint.transform.position;
            float distanceTravelPercent = 0f;

            transform.LookAt(endPos);//makes the game object look at the current end point

            while (distanceTravelPercent < 1f) {//4.while our travel percent is less than one. other words while were not at our end position
                distanceTravelPercent += Time.deltaTime * mySpeed;//5.we will update our travel percent with time.delta time and multiply by speed to increase the speed.
                transform.position = Vector3.Lerp(startPos, endPos, distanceTravelPercent);//6. then move the position of our enemy
                yield return new WaitForEndOfFrame();//7. we will then yield back to the ipdate function until the end of the frame has been completed.Then we will jump back to our co routnine
            }//this will then continue the while loop until our travel percent is greater than one.At which the while loop will be broken out of and the foreach loop will move to the next waypoint

            //No longer needed: transform.position = myWaypoint.transform.position;//the first transform.position is on the root of our enemy object we are reassigning the enemy object position to be the waypoints position.          
        }
        finishPoint();
    }

    //Can also be written like this:
    //void PrintingWaypointName()
    //{

    //foreach(var i in myPathWay)
    //{
    //    Debug.Log(i.name);
    //}

    //}
}


//In Unity, components are the parts that you attach to your GameObject. 
//The parts, or components, that you attach, or add, to your GameObject are what makes your GameObject do the things you want it to do.