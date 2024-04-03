using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GameOver()
    {
        // Carica la scena contenente l'oggetto GameOverScreen
        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Additive);

        // Trova l'oggetto GameOverScreen nella scena appena caricata
        GameOverScreen gameOverScreen = FindObjectOfType<GameOverScreen>();

        // Esegui le operazioni necessarie sull'oggetto GameOverScreen
        if (gameOverScreen != null)
        {
            gameOverScreen.Setup(); // Esegui il setup della schermata di game over
        }
    }
}
