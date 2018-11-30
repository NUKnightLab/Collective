using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour {

    private float resourcePoints;

    private float ghgPoints;

    public void changePoints(Slider slider)
    {
        resourcePoints = slider.value;
        ghgPoints = 30 - slider.value;
        Debug.Log(resourcePoints);
        Debug.Log(ghgPoints);
    }



    //set resource points when slider moves

    //send resource points to the next scene


}
