using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericScriot : MonoBehaviour
{
    [SerializeField] float age;
    [SerializeField] bool isActive;

    void Start()
    {
        myName("conor");
        myNumber(12);
        myAge(age);
        whileActive(isActive);
    }

     void Update()
    {
        
    }

    string myName(string name)
    {
        print(name);
        return name;
    }

    public float myAge(float age)
    {
        Debug.Log("my age is" + age);
        return age;    
    }

    public string secondExample()
    {
        return "eadoin";// because its expecting a string return because we have a string return type.
    }

    public void myNumber (int number)
    {
        print("The number passed in is" + number);

        int multiply = number * 10;
        print("The number after multiplying is :" + multiply);
    }

    public bool whileActive(bool isActive)
    {
        if (isActive == true)
        {
            Debug.Log("I'm true");
            return isActive;
        }

        if(isActive == false)
        {
            Debug.Log("I'm false");
            return isActive;
        }

        return isActive;
        
    }
   
}
