using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    public void LoadByIndex(int sceneIndex)
    {
        Debug.Log("Hello");
        SceneManager.LoadScene(sceneIndex);
    }
}
