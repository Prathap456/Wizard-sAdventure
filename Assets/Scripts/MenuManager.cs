using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GoToNextScene(int SceneNum)
    {
        SceneManager.LoadScene(SceneNum);
    }
    public void OnApplicationQuit()
    {
        SceneManager.LoadScene(0);
        Application.Quit();
    }
}
