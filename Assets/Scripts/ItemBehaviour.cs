using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour {

    public GameBehaviour gameManager;
    private CapsuleCollider capsCollider;

    /* Wird ausgeführt, wenn etwas in den Collider des Objekt gerät.
       Ist die Option "isTrigger" aktiviert, wird stattdessen OnTriggerEnter() ausgeführt
       (was erklärt, warum dann das Script nicht mehr funktioniert).
       Das Collision-Objekt "collision" ist das eindringende Objekt, dass so an die Funktion übergeben wird.
       Anders als bei OnTriggerEnter() muss das Objekt vom Typ Collision sein, nicht Collider.
    */


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehaviour>();
        // capsCollider = GetComponent<CapsuleCollider>();
    }

    /* void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Destroy(gameObject);
            UnityEngine.Debug.Log("Item collected!");
        }
    }
    */

    void OnCollisionEnter(Collision collision)
    {
        // 2
        if (collision.gameObject.name == "Player")
        {
            // 3
            Destroy(gameObject);
            // 4
            UnityEngine.Debug.Log("Item collected!");
            gameManager.Items += 1;
        }
    }
}
