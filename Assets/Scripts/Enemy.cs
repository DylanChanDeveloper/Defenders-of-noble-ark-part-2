using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 15;
    [SerializeField] int goldPenalty = 25;

    Bank myBank;

    // Start is called before the first frame update
    void Start()
    {
        myBank = FindObjectOfType<Bank>();
    }

    public void Reward()//returning void is like depositing money into your bank and not getting the recipet for it, were really just trusting everything has worked.
    {
        if(myBank == null) { return; }// guard statement if there is no bank then it will return out of our method(terminate the deposit early)?.
        myBank.deposit(goldReward);
    }

    public void stealGold()//returning void is like depositing money into your bank and not getting the recipet for it, were really just trusting everything has worked.
    {
        if (myBank == null) { return; }// guard statement if there is no bank then it will return out of our method(terminate the deposit early)?.
        myBank.withdraw(goldPenalty);
    }

}
