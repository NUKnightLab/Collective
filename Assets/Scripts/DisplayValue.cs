using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayValue : MonoBehaviour
{

    public Text textComponent;
	public RawImage imageComponent;
    public Texture tooLow;
    public Texture moderate;
    public Texture tooHigh;
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
			imageComponent.texture = tooLow;

            // Both outcomes are neutral
            textComponent.text = "NEUTRAL ending";
        }

		else if(resource<=75)
		{
            imageComponent.texture = moderate;

            if (decision == 0)
            {
                textComponent.text = "NEUTRAL ending";
            }
            else if (decision == 1)
            {
                textComponent.text = "GOOD ending";
            }

        }

        else
		{
            imageComponent.texture = tooHigh;

            // Both outcomes are bad
            textComponent.text = "BAD ending";
        }


    }
}
