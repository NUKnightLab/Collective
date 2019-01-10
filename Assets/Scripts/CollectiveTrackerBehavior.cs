using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class CollectiveTrackerBehavior : MonoBehaviour, ITrackableEventHandler
{
    string markerID;

    TrackableBehaviour collective_TrackableBehaviour;

    VuMarkManager collective_Vumark;

	// Use this for initialization
	void Start () {
        collective_TrackableBehaviour = GetComponent<TrackableBehaviour>();
        if(collective_TrackableBehaviour!=null)
        {
            collective_TrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        collective_Vumark = TrackerManager.Instance.GetStateManager().GetVuMarkManager();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if(newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackerFound();
        }
        else if(previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            OnTrackerLost();
        }
    }

    void OnTrackerFound()
    
    {
        foreach (var item in collective_Vumark.GetActiveBehaviours())
        {
			
           markerID = item.VuMarkTarget.InstanceId.StringValue;
           
            switch(markerID)
            {
                case "a":
                    SceneManager.LoadScene("FiskHall");
                    break;
                case "b":
                    SceneManager.LoadScene("WeberArch");
                    break;
                case "c":
                    SceneManager.LoadScene("RyanCenter");
                    break;
                case "d":
                    SceneManager.LoadScene("MillarChapel");
                    break;
                case "e":
                    SceneManager.LoadScene("DeeringMeadow");
                    break;
                case "f":
                    SceneManager.LoadScene("NorrisCenter");
                    break;
                case "g":
                    SceneManager.LoadScene("LuntHall");
                    break;
                case "h":
                    SceneManager.LoadScene("Lake");
                    break;
                case "i":
                    SceneManager.LoadScene("SilvermanHall");
                    break;
                case "j":
                    SceneManager.LoadScene("Ford");
                    break;
                case "k":
                    SceneManager.LoadScene("Kellogg");
                    break;
                case "l":
                    SceneManager.LoadScene("SPAC");
                    break;
            }

        }
    }

    void OnTrackerLost()
    {
        foreach (var item in collective_Vumark.GetActiveBehaviours())
        {
			Debug.Log("Lost Item: " + item);
            int targetObj = System.Convert.ToInt32(item.VuMarkTarget.InstanceId.NumericValue);
            transform.GetChild(targetObj - 1).gameObject.SetActive(false);
        }
    }
}
