using UnityEngine;

// Skrypt aktualizujący pozycję kamery na podstawie współrzędnych gracza z zadanymi ograniczeniami
public class CameraFollow : MonoBehaviour {

    // Współrzędna powyżej, której dalej kamera nie pójdzie. Jeżeli chcesz iść dalej w prawo to w Unity zwiększ tę liczbę. Reszta analogicznie
    [SerializeField]
    private float xMax;
    [SerializeField]
    private float yMax;

    [SerializeField]
    private float xMin;
    [SerializeField]
    private float yMin;

    public Rigidbody2D player;

	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, xMin, xMax), Mathf.Clamp(player.transform.position.y, yMin, yMax), transform.position.z);
    }
}
