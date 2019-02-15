using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour {

    static float totalResourcePoints;

    static float totalGhgPoints;

    public static float resourcePoints = 0;

    static float ghgPoints = 0;

    public static int decision;

    public void changePoints(Slider slider)
    {
        Transform parent = transform.parent.gameObject.transform;
        Transform the_living = parent.GetChild(5).gameObject.transform;
        Transform the_dead = parent.GetChild(6).gameObject.transform;
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
        //Out with the old!
        totalResourcePoints -= resourcePoints;
        totalGhgPoints -= ghgPoints;
        //In with the new!
        resourcePoints = slider.value;
        ghgPoints = slider.value;
        totalResourcePoints += resourcePoints;
        totalGhgPoints += ghgPoints;
        Debug.Log(resourcePoints);
        Debug.Log(totalGhgPoints);
    }

    public void makeDecision (int pick)
    {
        decision = pick;
    }



    //set resource points when slider moves

    //send resource points to the next scene


}
