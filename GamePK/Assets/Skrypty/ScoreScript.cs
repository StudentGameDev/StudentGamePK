using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


// W tej klasie obsługiwane są wyniki/stan bohatera
public class ScoreScript : MonoBehaviour {

    // Wyświetla nazwę gracza w oknie gry
    [SerializeField]
    Text usernameText;

    // Wyświetla liczbę punktów w oknie gry
    [SerializeField]
    Text scoreText;

    public static int coinAmount;
    public static int playerHealth;
    private static string username;
    private const int PointsForHealth = 50;

    void Start () {
        LoadScoreFromfile();
    }

    // Wywoływane, gdy aktualizacja stanu
    void Update()
    {
        scoreText.text = coinAmount.ToString();
    }

    // Wczytuje początkowy stan obiektu lub pomiędzy poziomami z pliku
    private void LoadScoreFromfile()
    {
        string path = String.Format(@"{0}\CurrentScore.txt", Environment.CurrentDirectory);

        using (StreamReader sr = File.OpenText(path))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                var lineElements = line.Split(';');
                username = lineElements.Length > 0 ? lineElements[0] : "Player";
                usernameText.text = username;
                if (lineElements.Length > 1 && int.TryParse(lineElements[1], out coinAmount))
                {
                    scoreText.text = lineElements[1];
                }
            }
        }
    }

    public static void SaveScoreTofile()
    {
        string path = String.Format(@"{0}\Scores.txt", Environment.CurrentDirectory);

        File.AppendAllText(path, username + ";" + coinAmount + ";" + DateTime.Now.ToString("dd.MM.yyyy") + Environment.NewLine);
    }

    public static void SaveCurrentStateToFile()
    {
        string path = String.Format(@"{0}\CurrentScore.txt", Environment.CurrentDirectory);

        coinAmount += playerHealth * PointsForHealth;

        File.WriteAllText(path, username + ";" + coinAmount + Environment.NewLine);
    }
}
