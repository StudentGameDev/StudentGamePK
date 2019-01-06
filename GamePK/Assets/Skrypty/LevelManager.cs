using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    public string backToMenu;
    public static float timer = 60;

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
        ScoreScript.playerHealth = 3;
        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        BossLife();
    }

    public void ChangeEnergyBoss(int energyValue)
    {
        ScoreScript.playerHealth += energyValue;
    }

    public int QuantityOfEnergy()
    {
        return ScoreScript.playerHealth;
    }

    void BossLife()
    {
        if (ScoreScript.playerHealth == 3)
            heart3.GetComponent<Renderer>().enabled = true;
        else
            heart3.GetComponent<Renderer>().enabled = false;

        if (ScoreScript.playerHealth >= 2)
            heart2.GetComponent<Renderer>().enabled = true;
        else
            heart2.GetComponent<Renderer>().enabled = false;

        if (ScoreScript.playerHealth >= 1)
            heart1.GetComponent<Renderer>().enabled = true;
        else
            heart1.GetComponent<Renderer>().enabled = false;
    }

    public void GameOver(AudioSource deathSource)
    {
        gameOver.gameObject.SetActive(true);
        ScoreScript.SaveScoreTofile();
        StartCoroutine(example(deathSource));
    }


    IEnumerator example(AudioSource deathSource)
    {
        Destroy(player);
        deathSource.Play();
        yield return new WaitForSeconds(deathSource.clip.length);

        SceneManager.LoadScene(backToMenu);
        Debug.Log("LAMISZ CIENIASIE!");

    }
} // end class LevelManager