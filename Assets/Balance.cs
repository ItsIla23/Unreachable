using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunamboloController : MonoBehaviour
{
    public float speed = 5f; // Velocità di movimento del funambolo
    public float rotationSpeed = 1f; // Velocità di rotazione del funambolo
    public float maxTiltAngle = 30f; // Angolo massimo di inclinazione consentito prima che il funambolo cada
    public float maxRotationForce = 10f; // Massima forza di rotazione consentita
    public float touchForce = 2f; // Intensità della forza applicata al tocco
    private Rigidbody rb;
    private bool isBalanced = true; // Indica se il funambolo è in equilibrio sulla corda
    private bool isTouching = false; // Indica se lo schermo è toccato

    private float touchStartTime; // Tempo iniziale del tocco
    private float maxRotationTime = 2f; // Tempo massimo per applicare una rotazione continua

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Otteniamo il componente Rigidbody del GameObject a cui è attaccato questo script
        Invoke("StartPendulum", 2f); // Dopo 2 secondi, avviamo il movimento pendolare del funambolo
    }

    void Update()
    {
        // Controllo degli input touch
        if (Input.touchCount > 0) // Controlliamo se c'è almeno un tocco sullo schermo
        {
            Touch touch = Input.GetTouch(0); // Otteniamo informazioni sul primo tocco rilevato
            if (touch.phase == TouchPhase.Began) // Controlliamo se il tocco è appena iniziato
            {
                isTouching = true; // Indichiamo che lo schermo è stato toccato
                touchStartTime = Time.time; // Registriamo il tempo iniziale del tocco
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouching = false; // Il tocco è terminato
            }
        }

        // Controllo dell'equilibrio del funambolo
        float tiltAngle = Vector3.Angle(Vector3.up, transform.up); // Calcoliamo l'angolo di inclinazione rispetto alla verticale
        if (tiltAngle > maxTiltAngle) // Se l'angolo di inclinazione è superiore all'angolo massimo consentito
        {
            isBalanced = false; // Il funambolo è in caduta
        }
    }

    void FixedUpdate()
    {
        if (!isBalanced) // Se il funambolo è in caduta
        {
            // Rimuoviamo il vincolo con la corda
            rb.constraints = RigidbodyConstraints.None;
            // Applichiamo una forza verso il basso per simulare la caduta
            rb.AddForce(Vector3.down * speed, ForceMode.Impulse);
        }
        else if (isTouching) // Se lo schermo è toccato, applica la forza di rotazione
        {
            // Calcoliamo la direzione del tocco rispetto alla posizione del funambolo
            Vector3 touchDirection = (Vector2)(Input.GetTouch(0).position - (Vector2)Camera.main.WorldToScreenPoint(transform.position));
            float rotationForce = touchDirection.x * (rotationSpeed * 0.005f); // Moduliamo la forza di rotazione
                                                                             // Applichiamo la forza di rotazione attorno all'asse Z
            rb.AddTorque(Vector3.forward * rotationForce * 0.005f * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }


    void StartPendulum()
    {
        float rotationForce = Random.Range(-maxRotationForce, maxRotationForce);
        rb.AddTorque(Vector3.forward * rotationForce * 0.03f, ForceMode.Impulse);
    }

}
