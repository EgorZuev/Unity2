using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private float _spawnRateEnemies;
    [SerializeField] private GameObject Template;

    private Transform[] _spawns;

    private void Start()
    {
        _spawns = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _spawns[i] = transform.GetChild(i);
        }

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        bool isActive = true;
        while (isActive)
        {
            for (int i = 0; i < _spawns.Length; i++)
            {
                Instantiate(Template, _spawns[i].position, Quaternion.identity);
                yield return new WaitForSecondsRealtime(_spawnRateEnemies);
            }
        }
    }
}
