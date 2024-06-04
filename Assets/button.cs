using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public void sceneChanger(string name) {
        SceneManager.LoadScene(name);
    }
    public void getOut() {
        Application.Quit();

    }

    public void ResetTheScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
