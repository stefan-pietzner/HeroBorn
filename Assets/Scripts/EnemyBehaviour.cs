using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System.Security.Cryptography;
using System.Diagnostics;

public class EnemyBehaviour : MonoBehaviour

{
    public Transform player;
    public Transform patrolRoute;
    public List<Transform> locations;

    private int locationIndex = 0;
    private NavMeshAgent agent;
    private int _lives = 3;

    public int EnemyLives 
    {
        get { return _lives; }
        private set
        {
            _lives = value;

            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                UnityEngine.Debug.Log("Enemy down.");
            }
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute) {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0) 
            return;

        agent.destination = locations[locationIndex].position;
        // Cleverer Einsatz des Modulo-Operators: Ist locations.Count == (locationIndex + 1) ergibt das immer Null, ansonsten den Wert von locationIndex +1.
        locationIndex = (locationIndex + 1) % locations.Count;
    }

    // Achtung: Datentyp Collider, nicht Collision wie bei OnCollisionEnter()!
    void OnTriggerEnter(Collider other)
    {
  
        if (other.name == "Player")
        {
            agent.destination = player.position;
            UnityEngine.Debug.Log("Player detected - attack!");
        }
    }

 
    void OnTriggerExit(Collider other) {

        if (other.name == "Player") 
        {
            UnityEngine.Debug.Log("Player out of range, resume patrol");
        }
    }

    void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Bullet(Clone)")
                {
                    EnemyLives -= 1;
                    UnityEngine.Debug.Log("Critical hit!");
                }
        }
}
