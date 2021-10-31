using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float _spawnRate;
    [SerializeField] private Enemy _template;

    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }

        

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(_spawnRate);
        bool isActive = true;
        while (isActive)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                Instantiate(_template, _spawnPoints[i].position, Quaternion.identity);
                yield return waitForSecondsRealtime;
            }
        }
    }
}
