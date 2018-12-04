using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;

public class GraphSample : MonoBehaviour {

    public GraphChart chart;
    private float Timer = 1f;
    private float X = 4f;

	// Use this for initialization
	void Start () {
        chart.DataSource.StartBatch();
        chart.DataSource.ClearCategory("Money");
        chart.DataSource.AddPointToCategory("Money", 0, 0);
        chart.DataSource.AddPointToCategory("Money", 1, 1);
        chart.DataSource.AddPointToCategory("Money", 2, 4);
        chart.DataSource.AddPointToCategory("Money", 3, 3);

        chart.DataSource.ClearCategory("Greenhouse Gas");
        chart.DataSource.AddPointToCategory("Greenhouse Gas", 0, 0);
        chart.DataSource.AddPointToCategory("Greenhouse Gas", 2, 4);
        chart.DataSource.AddPointToCategory("Greenhouse Gas", 3, 6);
        chart.DataSource.AddPointToCategory("Greenhouse Gas", 5, 8);

        chart.DataSource.EndBatch();

    }
	
	// Update is called once per frame
	void Update () {
        Timer -= Time.deltaTime;
        if(Timer <= 0f)
        {
            Timer = 1f;
            chart.DataSource.AddPointToCategoryRealtime("Money", X, UnityEngine.Random.value);
        }
		
	}
}
