using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Audio;

public class MenuCtrl : MonoBehaviour {

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
}
