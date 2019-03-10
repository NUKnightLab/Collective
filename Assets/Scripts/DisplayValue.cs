using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DisplayValue : MonoBehaviour
{
    public Texture DeeringBackground;
    public Texture LagoonBackground;
    public Texture SegalBackground;
    public Texture MapBackground;
    public RawImage imageComponent;
    public Text textComponent;

    void Awake()
    {
        switch (PointsController.currentLocation)
        {
            case "a":
                imageComponent.texture = DeeringBackground;
                break;
            case "b":
                imageComponent.texture = LagoonBackground;

                break;
            case "c":
                imageComponent.texture = SegalBackground;
                break;
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
                ShowLocation(PointsController.currentLocation, PointsController.spotsHit, PointsController.totalGhgPoints);
                break;
            case "EndGame":
                ShowEnd(PointsController.totalGhgPoints);
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
        else if (ghg <= 1)
        {
            textComponent.text = "Effects of your choices are accelerating and rapidly getting worse as fish are dying.\n";
            textComponent.text += "Proceed with caution.";
        }
        else
        {
            textComponent.text = "Snowstorm!!! The situation is so bad due to GHG emissions that a Polar Vortex has frozen life as a consequence.";
        }
    }

    public void ShowLocation(string location, int spotsHit, float ghg)
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
                textComponent.text = "You can harvest fish at " + prettyName + " for money.\n";
                textComponent.text += "You can keep accumulating this money, or you can invest it in new technology to help save the world.\n";
                textComponent.text += "Keep in mind that the more you harvest, the more you add to GHG in the atmosphere.";

                break;
            case 1:
                textComponent.text = "You've got this. You rush to " + prettyName + " to keep going.\n";
                textComponent.text += "Just a reminder! You've done this before but harvesting will result in higher GHG.";

                break;
            case 2:
                if (ghg < .25)
                {
                    textComponent.text = "The environment is looking great! Keep building on what you've done at the last location: " + prettyName;
                }
                else if (ghg < .5)
                {
                    textComponent.text = "The environment is doing well and you've increased your wealth! You want to keep going, so you head to the last location: " + prettyName;
                }
                else
                {
                    textComponent.text = "The environment is sufering - but you have one more chance to redeem yourself at the last location: "+prettyName;
                }
                break;
        }
    }

    public void ShowEnd(float ghg)
    {
        imageComponent.texture = MapBackground;
        if (ghg < .25)
        {
            textComponent.text = "Great job!\n\n You kept the environment clean while keeping GHG levels low, and you invested you money well.";
        }
        else if (ghg < .75)
        {
            textComponent.text = "You've reached the end!\n\n You made enough money to stay afloat and kept GHG to moderate levels! But, it will take a lot more than a few smart choices to imporve the environment.";
        }
        else
        {
            textComponent.text = "GAME OVER\n\n The world became too toxic. Your wealth cannot save you now.";
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
                if ((PointsController.totalGhgPoints >= PointsController.maxGhg)
                    | (PointsController.spotsHit == 3))
                {
                    PointsController.ChangeLastAction("EndGame");
                    SceneManager.LoadScene("EndGame");
                }
                else
                {
                    SceneManager.LoadScene("Map");
                }
                break;
            case "Scan":
                SceneManager.LoadScene("Harvest");
                break;
            case "EndGame":
                PointsController.ResetScores();
                SceneManager.LoadScene("LandingPage");
                break;
        }
    }
}
