using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

//MOVE THIS SCRIPT TO THE EDITOR FOLDER WHEN READY TO BUILD.

[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways]//script will now execute during play and edit mode
public class myCoOrdinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.green;
    [SerializeField] Color blockedColor = Color.red;

    TextMeshPro myLabel;
    Vector2Int myCoordinates = new Vector2Int();//using vector two int for representation of 2D vectors and points using integers.we are generating a vector by giving its components, we need to use new vector
    Waypoint waypoint;//giving the waypoint script a variable

    void Awake()//awake is the very first thing that will execute. meaning code encapsulated by the void awkae function will execute first.
    {
        myLabel = GetComponent<TextMeshPro>();//gets the textmeshpro component attached to this object and stores it in the myLabel variable
        myLabel.enabled = false; //makes the default value of label to be false
        CoordinateDisplay();//need to run the method in awake otherwise when we play the scene because of execute always the game will break if we dont call it in awake
        waypoint = GetComponentInParent<Waypoint>();// Waypoint script is on the route of our object and our coordinate label is buried in there in one of the children. getting access to the waypoint script and storing the access value into waypoint variable.
    }
    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)//means if the application is not playing run the methods below. aka this is only executing stuff in edit mode.
        {
            CoordinateDisplay();
            UpdateObjectName();
        }

        SetLabelColor();
         ToggleLabels();
    }

   void SetLabelColor()
    {
        if (waypoint.CanBePlaced)//accessing the CanBePlaced property method in waypoint script. 
        {
            myLabel.color = defaultColor;//accessing the myLabel color and changing it to default color
        }

        else
        {
            myLabel.color = blockedColor;//accessing the myLabel color and changing it to blocked color
        }
    }

    void CoordinateDisplay()
    {
        myCoordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);//we encapuslate transform.parent.position.x because of a conversion error, mathf.roundtoint returns a float to a int.Are coordinates are in multiples of ten. dividing it by the unityeditor move x will give us the coordinates for the current location
        myCoordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);//we encapuslate transform.parent.position.x because of a conversion error, mathf.roundtoint returns a float to a int. we are getting the z coordinate because we are working in the 2D x,z plain

        myLabel.text = myCoordinates.x + "," + myCoordinates.y;//changes the text in the textmeshpro "mylabel" to the corodinates of my coordinates x and y
    }

    void UpdateObjectName()
    {
        transform.parent.name = myCoordinates.ToString();//the coordinates are in int and we need to convert it to a string with the to string method. we then update the string values and change the transform parent names to the coordinates
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            myLabel.enabled = !myLabel.IsActive(); // this code means whenever we hit the c button we're going to set the current enabled state of our label to the opposite of whatever the current active is.
        }
    }

}
