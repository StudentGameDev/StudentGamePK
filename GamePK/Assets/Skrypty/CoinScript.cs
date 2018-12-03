using UnityEngine;

// Aktualizuje wyniki po kontakcie gracza z monetą
public class CoinScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        ScoreScript.coinAmount += 10;
        Destroy(gameObject);
    }
}
