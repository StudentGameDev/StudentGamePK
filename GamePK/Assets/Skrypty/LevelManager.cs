using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{

    [SerializeField]
    Text timeText;

    public float respawnDelay;
    public string backToMenu;
    public float timer;
    public static int timerToInt;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject gameOver;
    public GameObject boss;

    public Player player;

    // Use this for initialization
    void Start()
    {
        timer = timer == 0 ? 120 : timer;
        heart1 = GameObject.Find("heart1");
        heart2 = GameObject.Find("heart2");
        heart3 = GameObject.Find("heart3");
        boss = GameObject.Find("Activator");
        player = FindObjectOfType<Player>();   // wyszukaj skrypt Boss1
        ScoreScript.playerHealth = 3;
        gameOver.gameObject.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {

        if (timer >= 1)
        {
            timer -= Time.deltaTime;
            timerToInt = Mathf.FloorToInt(timer);
        }
        else
            timerToInt = 0;

        timeText.text = timerToInt.ToString();

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

    public void Restart()
    {
        if (boss != null)
        {
            var r = boss.GetComponent(typeof(WinterBossActivator)) as WinterBossActivator;

            if (r != null)
            {
                r.Reset();
            }
        }
    }
} // end class LevelManager