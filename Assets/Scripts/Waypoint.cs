using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower prefabTower;//In our waypoint script we dont have to get a reference to our tower script because, we already have it attached to our towerPrefab
    [SerializeField] bool canBePlaced;//did not delcare true or false because we set if the object bool is true in the inspector.
    

    public void Start()
    {
      
    }

    public bool CanBePlaced//this is a property method notice that there is no "()" vs a normal method that would have parmeter brackets.property being used in myCoOrdinateLabeler
    {  
        get{return canBePlaced;}

       // set { canBePlaced = value; }
    }


  
     void OnMouseDown()//is called when the user has pressed tge mouse button while over a collider.
    {
        if(canBePlaced)//The reason why we changed CreateTower to a bool is because if the object bool canBePlaced is ticked in the inspector than it will run the code below.
        {
            bool isPlaced = prefabTower.CreateTower(prefabTower, transform.position);//this is going to act somewhat like our instatiation method, we pass in the prefabTower thats attached to our waypoint and the position of our waypoint. if we managed to place a tower this will return true and if we didn't have enough money in our bank this will return false and isPlaced will be false.
            canBePlaced = !isPlaced;//this way we will no longer block tiles if our tower couldn't be created.
            //   canBePlaced = false;//we then set canBePlaced to false regardless if it worked or not.(old code)
        }//once we instatiated a tower to the tile set the canBePlaced flag is set to false to stop us from placing another tower.
        
    }

}
