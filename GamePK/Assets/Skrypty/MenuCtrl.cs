using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Kontroler menu
public class MenuCtrl : MonoBehaviour {

    [SerializeField]
    Text usernameText;

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void Exit(){
        Debug.Log("Time to quit!");
        Application.Quit();
    }

    public void ToggleVolume(){
        AudioListener.volume = AudioListener.volume == 0.0f ? 1.0f : 0.0f;
    }

    // Przy wprowadzaniu nazwy gracza zapisuje ją do pliku
    public void EnterName()
    {
        string path = String.Format(@"{0}\CurrentScore.txt", Environment.CurrentDirectory);

        using (StreamWriter sw = File.CreateText(path))
        {
            sw.Write(usernameText.text + ";");
        }
    }

    public void LoadSceneConfirm(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
