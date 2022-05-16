using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject myEnemiePrefab;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;// we can make the enemies spawn quickly they just cant all spawn at once.
    [SerializeField] [Range(0, 50)] int poolSize; //will stop our number going negitive, which would give us errors and limit the amount of instantiated object were going to have in our scene .

    GameObject[] Pool;

     void Awake()
    {
        populatePool();
    }

    void Start()
    {
        StartCoroutine(enemySpawn());//calling co-routine
      
    }

    IEnumerator enemySpawn()//co routine declaration
    {
            while (true) 
            {
            EnableObjectInPool();
                //EnableObjectInPool();
                yield return new WaitForSeconds(spawnTimer);
            }              
    }

    void EnableObjectInPool()
    {
        for (int i = 0; i < Pool.Length; i++)//loops through the Pool length 
        {
            if (Pool[i].activeInHierarchy == false)//if any of the pools items are found to not be active
            {
                Pool[i].SetActive(true);//the pool will be set active.
                return;//we then return early.
            }
        }
    }

    void populatePool()
    {
        Pool = new GameObject[poolSize];//populating the pool with the poolSize int variable.

        for (int i = 0; i < Pool.Length; i++)//for loop starts counting at element 0, then the for loop will keep counting as long as the pools length is less then. 
        {
            Pool[i] = Instantiate(myEnemiePrefab, transform);//the parent for the second parameter is the transform, which is our object in our hierarchy.
            //can access each element of our pool array by just saying that the pull at element I. we then instantiate the object and place it in our array.

            Pool[i].SetActive(false);//disables the pool by default
        }
    }
}

// void test()
//  {
//      for(int i = 0; i < Pool.Length; i++)
//    {
//         if (Pool[i].activeInHierarchy == false)
//         {
//            Pool[i].SetActive(true);
//            return;
//

//    }
// }


//while loops means while some condition is true.
//while(true) can be dangerious because if we dont give it a way to break out a infinate loop will occur and crash the game.
//the position and roatation is handled in our enemyMovement script so we dont need to use them in this insantiate.
//with this instatiation overload we just create the object and sets the parent for our newly created object.
//if we just have the overload were we create a enemy Prefab   Instantiate(myEnemiePrefab); it will create the object but wont put it anywhere.
