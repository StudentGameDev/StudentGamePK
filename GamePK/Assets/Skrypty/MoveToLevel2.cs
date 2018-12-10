using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToLevel2 : MonoBehaviour {

    [SerializeField] private string nextLevelWinter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gracz1"))
        {
            SceneManager.LoadScene(nextLevelWinter);
        }
    }

}
