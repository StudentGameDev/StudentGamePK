using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreboardItem : MonoBehaviour {

    [SerializeField]
    Text usernameText;

    [SerializeField]
    Text scoreText;

    [SerializeField]
    Text dateText;

    public void Setup(string username, string scores, string date)
    {
        //usernameText = GameObject.Find("UserName").GetComponent<Text>();
        usernameText.text = username;
        scoreText.text = scores.ToString();
        dateText.text = date;
    }
}
