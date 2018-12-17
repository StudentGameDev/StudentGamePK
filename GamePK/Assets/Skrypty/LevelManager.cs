using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    public float respawnDelay;
    public Player player;
    public GameObject heart1, heart2, heart3, gameOver;
    public int health;
    public string backToMenu;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }
    public IEnumerator RespawnCoroutine()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = player.respawnPoint;
        player.gameObject.SetActive(true);
    }

    public void LessHealth()
    {
        health -= 1;

        bool isAlive = CheckHealth();

        if (!isAlive)
        {
            GameOver();
        }

    }

    public bool CheckHealth()
    {
        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                return true;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                return true;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                return true;
            case 0:
                return false;
        }
        return false;
    }

    public void GameOver()
    {
        heart1.gameObject.SetActive(false);
        heart2.gameObject.SetActive(false);
        heart3.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
        SceneManager.LoadScene(backToMenu);
        Debug.Log("LAMISZ CIENIASIE!");
    }
}