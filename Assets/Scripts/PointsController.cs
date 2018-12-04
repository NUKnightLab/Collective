using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour {

    static float totalResourcePoints;

    static float totalGhgPoints;

    public static float resourcePoints;

    static float ghgPoints;

    public void changePoints(Slider slider)
    {
        resourcePoints = slider.value;
        ghgPoints = 30 - slider.value;
        totalResourcePoints += resourcePoints;
        totalGhgPoints += ghgPoints;
        Debug.Log(resourcePoints);
        Debug.Log(ghgPoints);
    }



    //set resource points when slider moves

    //send resource points to the next scene


}
