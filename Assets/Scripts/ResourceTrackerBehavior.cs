using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ResourceTrackerBehavior : MonoBehaviour, ITrackableEventHandler
{
    GameObject GUI;
   

    TrackableBehaviour resource_TrackableBehaviour;

    VuMarkManager resource_Vumark;
    // Use this for initialization
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        resource_TrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (resource_TrackableBehaviour != null)
        {
            resource_TrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        resource_Vumark = TrackerManager.Instance.GetStateManager().GetVuMarkManager();
    }

    // Update is called once per frame
    void Update()
    {

    }
  
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackerFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            OnTrackerLost();
        }
    }

    void OnTrackerFound()
    {
        foreach (var item in resource_Vumark.GetActiveBehaviours())
        {
            Transform parent = transform.parent.gameObject.transform;
            GameObject scanWindow = parent.GetChild(0).gameObject;
            GameObject slider = parent.GetChild(3).gameObject;
            GameObject button = parent.GetChild(4).gameObject;
            GameObject livingFish = parent.GetChild(5).gameObject;
            GameObject deadFish = parent.GetChild(6).gameObject;

            Debug.Log("Found!");
            //int targetObj = System.Convert.ToInt32(item.VuMarkTarget.InstanceId.NumericValue);
            scanWindow.SetActive(false);
            slider.SetActive(true);
            button.SetActive(true);
            livingFish.SetActive(true);
            deadFish.SetActive(true);
            //Debug.Log(transform.GetChild((int)0).gameObject.activeInHierarchy);
            //GUI.SetActive(false);
        }
    }

    void OnTrackerLost()
    {
        foreach (var item in resource_Vumark.GetActiveBehaviours())
        {
            //Debug.Log("Lost!");
            //int targetObj = System.Convert.ToInt32(item.VuMarkTarget.InstanceId.NumericValue);
            //transform.GetChild((int)0).gameObject.SetActive(false);

        }
    }
   
}