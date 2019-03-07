using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DisplayValue : MonoBehaviour
{

    public Text textComponent;
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
        Debug.Log(PointsController.totalGhgPoints);
        Debug.Log("HELP ME");
        if (textComponent == null)
        {
            Debug.Log("You must assign a text component!");
            this.enabled = false;
            return;
        }
        switch (PointsController.lastAction)
        {
            case "Harvest":
                ShowHarvest(PointsController.lastHarvest, PointsController.totalResourcePoints);
                break;
            case "Invest":
                ShowInvest(PointsController.lastInvest);
                break;
            case "MicroActions":
                ShowGHG(PointsController.totalGhgPoints / PointsController.maxGhg);
                break;
            case "Scan":
                ShowLocation(PointsController.currentLocation, PointsController.spotsHit);
                break;

        }
    }

    public void ShowHarvest(float new_money, float total)
    {
        textComponent.text = "You just harvested $" + new_money + " worth of fish. You now have $" + total + " in total. \n\n";
        textComponent.text += "Now you must decide how much you want to invest in making Northwestern more sustainable.";

    }

    public void ShowInvest(float new_money)
    {
        textComponent.text = "You just invested $" + new_money + " into making NU more sustainable.\n\n";
        textComponent.text += "Investment So Far: $" + PointsController.totalInvestPoints +"\n";
        textComponent.text += "The more you invest, the better for the environment long-term.\n\n";
        textComponent.text += "You can add to this by taking action directly.";
    }

    public void ShowGHG(float ghg)
    {
        if (ghg < .25)
        {
            textComponent.text = "The world is looking great. We're actually improving the environment! \n";
            textComponent.text += "Head to the next location.";
        }
        else if (ghg < .5)
        {
            textComponent.text = "The world is roughly unchanged.\n";
            textComponent.text += "Head to the next location.";
        }
        else if (ghg < .75)
        {
            textComponent.text = "The world is starting to see the effects of climate change. \n";
            textComponent.text += "Proceed with caution.";
        }
        else if (ghg < 1)
        {
            textComponent.text = "Effects of your choices are accelerating and rapidly getting worse as fish are dying.\n";
            textComponent.text += "Proceed with caution.";
        }
        else
        {
            textComponent.text = "Snowstorm!!! The situation is so bad due to GHG emissions that a Polar Vortex has frozen life as a consequence.";
        }
    }

    public void ShowLocation(string location, int spotsHit)
    {
        string prettyName ="";
        switch (location)
        {
            case "a":
                prettyName = "Deering Library";
                break;
            case "b":
                prettyName = "the Lagoon";
                break;
            case "c":
                prettyName = "Segal Visitor Center";
                break;
        }
        switch (spotsHit)
        {
            case 0:
                textComponent.text = "You can harvest dish at " + prettyName + " for money.\n";
                textComponent.text += "You can keep accumulating this money, or you can invest it in new technology to help save the world.\n";
                textComponent.text += "Keep in mind that the more you harvest, the more you add to GHG in the atmosphere.";
                break;
            case 1:
                textComponent.text = "You've got this. You rush to " + prettyName + " to keep going.\n";
                textComponent.text += "Just a reminder! You've done this before but harvesting will result in higher GHG.";
                break;
            case 2:
                textComponent.text = "One final location! This is your last chance to make good choices.";
                break;
        }
    }

    public void LeaveResults()
    {
        switch (PointsController.lastAction)
        {
            case "Harvest":
                SceneManager.LoadScene("Invest");
                break;
            case "Invest":
                SceneManager.LoadScene("MicroActions");
                break;
            case "MicroActions":
                if (PointsController.totalGhgPoints == PointsController.maxGhg)
                {
                    SceneManager.LoadScene("GameOver");
                }
                SceneManager.LoadScene("Map");
                break;
            case "Scan":
                SceneManager.LoadScene("Harvest");
                break;
        }
    }
}
