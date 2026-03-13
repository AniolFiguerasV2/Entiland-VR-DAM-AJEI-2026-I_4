using System.Collections;
using UnityEngine;

public class SpawnClients : MonoBehaviour
{
    public GameObject client;
    public bool isFull = false;
    public int currentclients = 0;
    public int maxclients = 5;
    public Transform destinationPoint;
    public Transform[] spawnPoints;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    public void SpawnRanPosition()
    {
        if (!isFull)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[randomIndex];
            GameObject tempClient = Instantiate(client, spawnPoint.position, Quaternion.identity);
            tempClient.GetComponent<ClientOptions>().destination = destinationPoint;
            currentclients++;
            if(currentclients == maxclients)
            {
                isFull = true;
            }
        }
        else if (isFull)
        {
            if(currentclients <= maxclients)
            {
                isFull= false;
            }
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnRanPosition();
            yield return new WaitForSeconds(30f);
        }
    }
}
