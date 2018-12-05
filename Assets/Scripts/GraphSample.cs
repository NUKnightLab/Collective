using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChartAndGraph;

public class GraphSample : MonoBehaviour {

    public GraphChart chart;

	// Use this for initialization
	void Start () {
        chart.DataSource.StartBatch();
        chart.DataSource.ClearCategory("Money1");
        chart.DataSource.AddPointToCategory("Money1", 0, 0);
        chart.DataSource.AddPointToCategory("Money1", 1, 145);
        chart.DataSource.AddPointToCategory("Money1", 5, 620);
        chart.DataSource.AddPointToCategory("Money1", 9, 1073);

        chart.DataSource.ClearCategory("Money2");
        chart.DataSource.AddPointToCategory("Money2", 0, 0);
        chart.DataSource.AddPointToCategory("Money2", 1, 130);
        chart.DataSource.AddPointToCategory("Money2", 5, 385);
        chart.DataSource.AddPointToCategory("Money2", 9, 1030);

        chart.DataSource.ClearCategory("Money3");
        chart.DataSource.AddPointToCategory("Money3", 0, 0);
        chart.DataSource.AddPointToCategory("Money3", 1, 145);
        chart.DataSource.AddPointToCategory("Money3", 5, 620);
        chart.DataSource.AddPointToCategory("Money3", 9, 1072);

        chart.DataSource.EndBatch();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
