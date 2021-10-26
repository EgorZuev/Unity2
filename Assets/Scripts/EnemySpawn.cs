using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float _spawnRate;
    [SerializeField] private GameObject _template;

    private Transform[] _spawnPoints;
    private WaitForSecondsRealtime _waitForSecondsRealtime;

    private void Start()
    {
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }

        _waitForSecondsRealtime = new WaitForSecondsRealtime(_spawnRate);

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        bool isActive = true;
        while (isActive)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                Instantiate(_template, _spawnPoints[i].position, Quaternion.identity);
                yield return _waitForSecondsRealtime;
            }
        }
    }
}
