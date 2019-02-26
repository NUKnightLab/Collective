using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishies : MonoBehaviour
{
    public GameObject FishContainer;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < FishContainer.transform.childCount; i++)
        {
            FishContainer.transform.GetChild(i).gameObject.transform.localScale = Vector3.one * (1.0f / 2.0f)* Mathf.Sqrt(Mathf.Cos(PointsController.totalGhgPoints * Mathf.PI / 2 / 1000));
            Debug.Log((PointsController.totalGhgPoints / 2000));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
