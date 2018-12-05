using UnityEngine;

// Aktualizuje wyniki po kontakcie gracza z monetą
public class CoinScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col is EdgeCollider2D)
            return;
        ScoreScript.coinAmount += 10;
        Destroy(gameObject);
    }
}
