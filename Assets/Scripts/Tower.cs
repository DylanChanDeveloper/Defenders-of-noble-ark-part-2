using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 50;
   public bool CreateTower(Tower tower, Vector3 myPosition)//for the parameters of this method it will accept a prefab of type tower and a position in this case, we changed the return type to bool so we can later create a tower based on our bank balance.
    {
        Bank bank = FindObjectOfType<Bank>();//we get the Bank object

        if(bank == null)//guard statement if there is no bank.
        {
            return false;
        }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, myPosition, Quaternion.identity);//passing in the tower gameobject the vector3 myPosition and quaterion identity.
            bank.withdraw(cost);
            return true;
        }

        return false;//then if all else fails return false.
    }
}
