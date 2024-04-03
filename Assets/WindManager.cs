using UnityEngine;
using System.Collections;

public class WindManager : MonoBehaviour
{
    public float baseMinInterval = 5f;
    public float baseMaxInterval = 10f;
    public float baseMinIntensity = 0.5f;
    public float baseMaxIntensity = 1.5f;
    public float windDuration = 1f;
    public Transform windCollider;
    public Transform player;
    public ScoreManager scoreManager; // Aggiungiamo il riferimento al ScoreManager

    private float nextWindTime;

    void Start()
    {
        nextWindTime = Time.time + Random.Range(baseMinInterval, baseMaxInterval);
    }

    void Update()
    {
        if (Time.time >= nextWindTime)
        {
            GenerateWind();
            CalculateNextWindTime();
            UpdateWindParameters();
        }
    }

    void GenerateWind()
    {
        float score = scoreManager.score; // Ottieni il punteggio dallo ScoreManager

        // Calcola l'intensità e la direzione del vento basandoti sul punteggio
        float windIntensity = CalculateWindIntensity(score);
        float windDirection = Random.value > 0.5f ? -1f : 1f; // Direzione casuale o basata su qualche logica, a tua scelta

        Debug.Log("Il vento sta soffiando con direzione: " + windDirection);
        Debug.Log("Intensità del vento: " + windIntensity);

        // Applica il vento al giocatore
        if (player != null)
        {
            Vector3 windTorque = new Vector3(0f, 0f, windIntensity * windDirection);
            player.GetComponent<Rigidbody>().AddTorque(windTorque, ForceMode.Impulse);
        }

        // Calcola il tempo per la prossima raffica di vento
        CalculateNextWindTime();
    }


    float CalculateWindIntensity(float score)
    {

        // Normalizza il punteggio tra 0 e 1
        float normalizedScore = Mathf.Clamp01(score / 50f);


        if (score < 50)
        {
            // Se il punteggio è inferiore a 50, l'intensità del vento è minore
            return Mathf.Lerp(0.25f, 0.5f, Mathf.Clamp01(score / 50f));

        }
        else
        {
            // Se il punteggio è uguale o superiore a 50, generiamo un' intensità casuale
            return Random.Range(0.5f, baseMaxIntensity);
        }
    }



    void CalculateNextWindTime()
    {
        nextWindTime = Time.time + Random.Range(baseMinInterval, baseMaxInterval);
    }

    void UpdateWindParameters()
    {
        float score = scoreManager.score; // Ottieni il punteggio dallo ScoreManager

        // Calcola i nuovi valori dell'intervallo del vento basati sul punteggio
        float intervalMultiplier = Mathf.Clamp01(score / 100f);
        float newMinInterval = baseMinInterval * (1f - intervalMultiplier);
        float newMaxInterval = baseMaxInterval * (1f - intervalMultiplier);

        // Riduci ulteriormente l'intervallo se il punteggio è basso
        if (score < 50)
        {
            newMinInterval *= 1.5f;
            newMaxInterval *= 1.5f;
        }

        // Imposta i nuovi valori dell'intervallo del vento
        baseMinInterval = newMinInterval;
        baseMaxInterval = newMaxInterval;

        // Ricalcola il tempo per la prossima raffica di vento
        CalculateNextWindTime();
    }




}
