using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private int MaxEnemyCount;
    [SerializeField]
    private float EnemySpawnTimer = 1.5f;
    [SerializeField]
    private float DangerRadius = 3.0f;
    private bool _canSpawn=true;
    private int _enemyCount;
    private RandomUtils rnd;

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            rnd = new RandomUtils();
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator spawn_delay()
    {
        if (!_canSpawn)
        {
            yield return new WaitForSeconds(EnemySpawnTimer);
            _canSpawn = true;
        }
    }
    private void Update()
    {
        if (_canSpawn && _enemyCount < MaxEnemyCount)
        {
            Instantiate(enemy,rnd.getRandomPos(DangerRadius),Quaternion.identity);
            _enemyCount++;
        }
    }
}
