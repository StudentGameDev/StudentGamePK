using UnityEngine;
using UnityEngine.UI;

// Pojedynczy element na liście z wynikami
public class PlayerScoreboardItem : MonoBehaviour {

    [SerializeField]
    Text usernameText;

    [SerializeField]
    Text scoreText;

    [SerializeField]
    Text dateText;

    public void Setup(string username, string scores, string date)
    {
        usernameText.text = username;
        scoreText.text = scores.ToString();
        dateText.text = date;
    }
}
