using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PointsController : MonoBehaviour {
    public Text textComponent;

    public static float totalResourcePoints = 0;

    public static float totalGhgPoints = 0;

    static float totalInvestPoints = 0;

    public static float resourcePoints = 0;

    static float ghgPoints = 0;

    static float investPoints = 0;

    public static int decision;

    public void changePoints(Slider slider)
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
        resourcePoints = Mathf.Round(slider.value * Mathf.Cos(totalGhgPoints * Mathf.PI / 2 / 1000));
        ghgPoints = Mathf.Round(Mathf.Pow(slider.value, 2-totalInvestPoints/1000)/100);

        textComponent.text = "Effect If Harvested:\n";
        textComponent.text += "$"+resourcePoints+"\n";
        textComponent.text += ghgPoints + " tons of Carbon\n";

        Debug.Log(resourcePoints);
        Debug.Log(totalGhgPoints);
    }

    public void makeDecision (int pick)
    {
        decision = pick;
    }

    public void HarvestAmount()
    {
        totalResourcePoints += resourcePoints;
        totalGhgPoints += ghgPoints;

        if (totalGhgPoints >= 1000)
        {
            SceneManager.LoadScene("EndGame");
        }

    }



    //set resource points when slider moves

    //send resource points to the next scene


}
