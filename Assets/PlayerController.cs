using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreManager scoreManager; // Assicurati di trascinare il riferimento al ScoreManager nell'Inspector di Unity
    private bool gameOverTriggered = false; // Aggiungi questa variabile per tenere traccia se la scena di game over è già stata caricata

    void Update()
    {
        // Controlla se il player è caduto (esempio: quando la sua posizione Y è inferiore a un certo valore)
        if (transform.position.y < -82f && !gameOverTriggered) // Modifica il valore di -10f in base alla tua logica di caduta
        {
            // Imposta il trigger del game over su true per evitare il caricamento ripetuto della scena
            gameOverTriggered = true;

            // Chiama la funzione StopScore() del ScoreManager per fermare il punteggio
            scoreManager.StopScore();

            // Carica la scena di game over solo se non è stata già caricata
            SceneManager.LoadScene("GameOverScene", LoadSceneMode.Additive);
        }
    }
}

