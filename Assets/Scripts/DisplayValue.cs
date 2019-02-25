using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayValue : MonoBehaviour
{

    public Text textComponent;
	public RawImage imageComponent;
    //public Texture tooLow;
    //public Texture moderate;
    //public Texture tooHigh;
    private int myIntValue;


    public int MyIntValue
    {
        get { return myIntValue; }
        set
        {
            if (myIntValue != value)
            {
                //Here we're only updating the text shown on screen when the value is changed
                //myIntValue = value;
                //UpdateText(myFloatValue, myIntValue);
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
        if (imageComponent == null)
        {
            Debug.Log("You must assign an image component!");
            this.enabled = false;
            return;
        }
        UpdateText(PointsController.resourcePoints, PointsController.decision);
    }

    void UpdateText(float resource, int decision)
    {
        //Update the text shown in the text component by setting the `text` variable
        //textComponent.text = "You earned: " + resource + " resource  points";

        // decision == 0: Decision to save money
        // decision == 1: Decision to invest money into something

		if(resource<25)
		{

            // Both outcomes are neutral
            textComponent.text = "You harvested fish and chose to save the money for a rainy day.";
        }

		else if(resource<=75)
		{

            if (decision == 0)
            {
                textComponent.text = "You harvested fish and chose to save the money for a rainy day.";
            }
            else if (decision == 1)
            {
                textComponent.text = "You've used your resources to invest in wind turbines, which improves" +
                	" Northwestern's energy by 20%. \n \nYou wonder, 'where else can I get resources?'";
            }

        }
        else
		{
            // Both outcomes are bad
            textComponent.text = "In your rush to gain resources and invest in the environment," +
            	" you forgot about your health. \n \nYou're in no condition to continue and are " +
            	"locked away to recover.";
        }


    }
}
