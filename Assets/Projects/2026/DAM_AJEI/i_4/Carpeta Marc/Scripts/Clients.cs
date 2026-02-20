using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Clients : MonoBehaviour
{
    public Transform[] patrolPoints;
    [SerializeField] private bool isMoving;
    //Hacer variables para spawnear aqui los npc
    public int waypointIndex;
    public float movespeed;

    //Variables de velocidad NPC
    private float speed = 5f;


    //Variables de Spawn
    private SpawnClients waveSpawner;
    private float countdown = 5f;

    void Start()
    {
        waveSpawner = GetComponentInParent<SpawnClients>();
        //StartMoving();
    }

    
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);

        countdown -= Time.deltaTime;
        
        //Logica de conteo para que los clientes se marchen

        if (!isMoving)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[0].position, Time.deltaTime * movespeed);
    }


    public void StartMoving()
    {
        waypointIndex = 0;
        isMoving = true;
    }
}
