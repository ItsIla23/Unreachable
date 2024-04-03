using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public ScoreManager scoreManager; // Riferimento al ScoreManager
    public TextMeshProUGUI pointsText;

    // Metodo per impostare e aggiornare la schermata di game over
    public void Setup()
    {
        // Mostra la schermata di game over
        gameObject.SetActive(true);

        // Ottieni il punteggio dallo ScoreManager
        float score = scoreManager.score;

        // Mostra il punteggio nella schermata di game over
        pointsText.text = "Score: " + score.ToString() + "m";
    }

    // Metodo chiamato quando la schermata di game over viene attivata
    void OnEnable()
    {
        // Chiama il metodo Setup per aggiornare il punteggio ogni volta che la schermata di game over viene attivata
        Setup();
    }

    // Metodo per ricaricare la scena principale del gioco
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    // Metodo per chiudere l'applicazione
    public void QuitGame()
    {
        Application.Quit();
    }
}
