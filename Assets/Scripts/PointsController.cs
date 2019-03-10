using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PointsController : MonoBehaviour
{
    public Text textComponent;

    public static float totalResourcePoints = 0;
    public static float totalGhgPoints = 0;
    public static float totalInvestPoints = 0;

    public static float resourcePoints = 0;
    public static float ghgPoints = 0;
    public static float investPoints = 0;

    public static float lastHarvest = 0;
    public static float lastInvest = 0;
    public static float lastMicro = 0;

    public static float maxGhg = 101;
    public static float maxInvest = 300;

    public static int microEffect =0;

    public static int spotsHit = 0;

    public static string lastAction;
    public static string currentLocation;
    public static List<string> visited = new List<string>();


    public void changeHarvest(Slider slider)
    {
        Transform parent = transform.parent.gameObject.transform;
        Transform the_living = parent.GetChild(5).gameObject.transform;
        Transform the_dead = parent.GetChild(6).gameObject.transform;
        GameObject textbox = parent.GetChild(0).gameObject;

        if (transform.gameObject.activeInHierarchy)
        {
            for (int i = 0; i < the_living.transform.childCount; i++)
            {
                float perfish = slider.maxValue / the_living.transform.childCount;
                if (slider.value > i * perfish)
                {
                    Debug.Log("KILL NUMBER " + i.ToString());
                    the_living.GetChild(i).gameObject.SetActive(false);
                    the_dead.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("SAVE NUMBER " + i.ToString());
                    the_living.GetChild(i).gameObject.SetActive(true);
                    the_dead.GetChild(i).gameObject.SetActive(false);
                }
            }
        }

        //In with the new!
        resourcePoints = Mathf.Round(slider.value * Mathf.Cos(Mathf.Max(totalGhgPoints,0) / maxGhg * Mathf.PI / 2));
        ghgPoints = Mathf.Round(Mathf.Pow(slider.value, 2 - totalInvestPoints / maxInvest) / slider.maxValue);

        textComponent.text = "Effect If Harvested:\n";
        textComponent.text += "$" + resourcePoints + "\n";
        textComponent.text += ghgPoints + " tons of Carbon\n";
    }

    public void HarvestAmount()
    {
        totalResourcePoints += resourcePoints;
        totalGhgPoints += ghgPoints;
        lastAction = "Harvest";
        lastHarvest = resourcePoints;
        resourcePoints = 0;
        SceneManager.LoadScene("ResultScreen");
    }

    public void changeInvest(Slider slider)
    {
        investPoints = Mathf.Round(slider.value / 100 * Mathf.Min(totalResourcePoints, maxInvest - totalInvestPoints));
        Debug.Log(slider.value);
        textComponent.text = "New Investment Amount:\n";
        textComponent.text += "$" + investPoints + "\n";
    }

    public void InvestAmount()
    {
        totalResourcePoints -= investPoints;
        totalInvestPoints += investPoints;
        lastAction = "Invest";
        lastInvest = investPoints;
        investPoints = 0;

        SceneManager.LoadScene("ResultScreen");
    }
    public static void ChangeMicroAction(int impact)
    {
        microEffect = impact;
    }
    public static void ChangeLastAction(string action)
    {
        lastAction = action;
    }
    public void MicroAction()
    {
        totalGhgPoints += microEffect;
        Debug.Log(totalGhgPoints);
        lastAction = "MicroActions";
        spotsHit++;
        lastMicro = microEffect;
        microEffect = 10;
        SceneManager.LoadScene("ResultScreen");
    }
    public static void ResetScores()
    {
        totalResourcePoints = 0;
        totalGhgPoints = 0;
        totalInvestPoints = 0;

        spotsHit = 0;
        visited = new List<string>();
}
}
