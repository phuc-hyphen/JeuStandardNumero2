using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public Transform[] spawnPoints;
    [SerializeField]
    public GameObject[] enemies;

    public float timeBetweenWaves = 5f;
    private float countdown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (countdown <= 0f)
        {
            int randEnemy = Random.Range(0, enemies.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            GameObject clone = (GameObject)Instantiate(enemies[randEnemy], spawnPoints[randSpawnPoint].position, Quaternion.identity);
            
            Destroy(clone, 5f);

            countdown = timeBetweenWaves;
        }
        
        countdown -= Time.deltaTime;
        
    }
}
