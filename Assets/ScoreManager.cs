using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Riferimento al testo per visualizzare il punteggio
    public float score = 0f; // Punteggio corrente
    public Transform ropeTransform; // Riferimento al transform della corda (assicurati di assegnarlo nell'editor Unity)
    public float scoreIncrementInterval = 2f;
    public GameManager gameManager; // Riferimento al gestore del gioco
    private bool scoreStopped = false; // Flag per indicare se l'incremento del punteggio è stato fermato

    void Start()
    {
        // Avvia l'incremento del punteggio ogni 2 secondi
        InvokeRepeating("IncrementScore", scoreIncrementInterval, scoreIncrementInterval);
    }

    void IncrementScore()
    {
        if (!scoreStopped)
        {
            // Incrementa il punteggio solo se l'incremento non è stato fermato
            score++;

            // Aggiorna il testo del punteggio nell'interfaccia utente
            UpdateScoreText();

            // Nel momento in cui il gioco termina o il punteggio viene calcolato
            
            PlayerPrefs.SetFloat("Score", score);
            PlayerPrefs.Save();
            
        }
    }

    public void StopScore()
    {
        scoreStopped = true; // Imposta il flag per fermare l'incremento del punteggio
        CancelInvoke("IncrementScore");


    }

    

    // Metodo chiamato quando il giocatore perde
    public void LoseGame()
    {
        // Attiva la schermata di game over
        gameManager.GameOver();
    }

    private void UpdateScoreText()
    {
        // Aggiorniamo il testo per visualizzare il punteggio nella UI
        if (scoreText != null)
        {
            // Convertiamo il punteggio in metri arrotondando al numero intero più vicino
            int scoreInMetri = Mathf.RoundToInt(score);
            // Aggiorniamo il testo del punteggio
            scoreText.text = "Score: " + scoreInMetri.ToString() + " m";
        }
    }
}
