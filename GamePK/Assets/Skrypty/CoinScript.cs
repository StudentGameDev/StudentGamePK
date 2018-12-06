using UnityEngine;

// Aktualizuje wyniki po kontakcie gracza z monetą
public class CoinScript : MonoBehaviour {

    public AudioSource tickSource;

    void Start()
    {
        tickSource = GetComponent<AudioSource>();
    }

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col is EdgeCollider2D || col.name != "Gracz1")
            return;

        tickSource.Play();
        ScoreScript.coinAmount += 10;
        AudioSource.PlayClipAtPoint(tickSource.clip, col.transform.position);
        Destroy(gameObject);
    }
}
