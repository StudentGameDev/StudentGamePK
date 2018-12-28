using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int playerHealth { get; set; }
    public float respawnDelay;
    public string backToMenu;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject gameOver;

    public Player player;

    // Use this for initialization
    void Start()
    {
        heart1 = GameObject.Find("heart1");
        heart2 = GameObject.Find("heart2");
        heart3 = GameObject.Find("heart3");
        player = FindObjectOfType<Player>();   // wyszukaj skrypt Boss1
        playerHealth = 3;
        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        BossLife();
    }

    public void ChangeEnergyBoss(int energyValue)
    {
        playerHealth += energyValue;
    }

    public int QuantityOfEnergy()
    {
        return playerHealth;
    }

    void BossLife()
    {
        if (playerHealth == 3)
            heart3.GetComponent<Renderer>().enabled = true;
        else
            heart3.GetComponent<Renderer>().enabled = false;

        if (playerHealth >= 2)
            heart2.GetComponent<Renderer>().enabled = true;
        else
            heart2.GetComponent<Renderer>().enabled = false;

        if (playerHealth >= 1)
            heart1.GetComponent<Renderer>().enabled = true;
        else
            heart1.GetComponent<Renderer>().enabled = false;
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        SceneManager.LoadScene(backToMenu);
        Debug.Log("LAMISZ CIENIASIE!");
    }
} // end class LevelManager