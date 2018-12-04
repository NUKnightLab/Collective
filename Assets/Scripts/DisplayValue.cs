using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayValue : MonoBehaviour
{

    public Text textComponent;
    private int myIntValue;
    public int MyIntValue
    {
        get { return myIntValue; }
        set
        {
            if (myIntValue != value)
            {
                //Here we're only updating the text shown on screen when the value is changed
                myIntValue = value;
                UpdateText(myIntValue);
            }
        }
    }

    void Awake()
    {
        Debug.Log("resource points are" + PointsController.resourcePoints);
        //If text hasn't been assigned, disable ourselves
        if (textComponent == null)
        {
            Debug.Log("You must assign a text component!");
            this.enabled = false;
            return;
        }
        UpdateText(PointsController.resourcePoints);
    }

    void UpdateText(float resource)
    {
        //Update the text shown in the text component by setting the `text` variable
        textComponent.text = "You earned: " + resource + " resource  points";
    }
}
