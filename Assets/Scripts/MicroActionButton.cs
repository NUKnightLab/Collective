using UnityEngine;
using System.Collections;

public class MicroActionButton : MonoBehaviour
{
    public GameObject selection;
    public GameObject button;

    public void Select(int impact)
    {
        selection.transform.position = button.transform.position;
        PointsController.microEffect = impact;
    }




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
