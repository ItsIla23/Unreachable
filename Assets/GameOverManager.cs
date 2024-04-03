using UnityEngine;
using UnityEngine.Events;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverScreen; // Riferimento alla schermata di game over

    void Start()
    {
        // Assicurati che la schermata di game over sia disattivata all'avvio
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    // Metodo per attivare la schermata di game over quando il giocatore perde
    public void OnPlayerLost()
    {
        // Attiva la schermata di game over
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
