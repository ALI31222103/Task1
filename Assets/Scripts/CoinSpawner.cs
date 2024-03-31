using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private GameObject coinPrefab;

    private int currentPoint = -1;

    void Start()
    {
        SpawnCoin();
    }

    void SpawnCoin()
    {
        int nextPoint = currentPoint;
        while (nextPoint == currentPoint)
        {
            nextPoint = Random.Range(0, spawnPoints.Count);
        }
        currentPoint = nextPoint;
        Transform point = spawnPoints[currentPoint];

        GameObject coinObject = Instantiate(coinPrefab, point.position, point.rotation);
        if (coinObject.TryGetComponent<Coin>(out Coin coin))
        {
            coin.onCollected.AddListener(GameManager.instance.OnCoinCollected);
            coin.onCollected.AddListener(SpawnCoin);
        }
    }
}