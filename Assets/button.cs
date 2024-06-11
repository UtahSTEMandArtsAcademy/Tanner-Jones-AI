using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    public void sceneChanger(string name) {
        SceneManager.LoadScene(name);
    }
    public void getOut() {
        Application.Quit();

    }

    public void ResetTheScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
        }
        if(isPaused == true){
            pauseMenu.SetActive(true);
        }
        else{
            pauseMenu.SetActive(false);
        }
    }
}
