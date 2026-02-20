using System.Collections;
using UnityEngine;

public class SpawnClients : MonoBehaviour
{
    [SerializeField] private float countdown;

    [SerializeField] private GameObject spawnPoint;

    public Wave[] waves;

    private int currentWaveIndex = 0;

    void Start()
    {
        for (int i = 0;i < waves.Length; i++)
        {
            waves[i].clientsLeft = waves[i].clients.Length;
        }
    }


    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown < 0)
        {
            countdown = waves[currentWaveIndex].timeToNextEnemy;
            StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < waves[currentWaveIndex].clients.Length; i++)
        {
            Clients client = Instantiate(waves[currentWaveIndex].clients[i], spawnPoint.transform); ;

            client.transform.SetParent(spawnPoint.transform);

            yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
        }
    }
}

[System.Serializable]
public class Wave
{
    public Clients[] clients;
    public float timeToNextEnemy;
    public float timeToNextWave;

    [HideInInspector] public int clientsLeft;
}
