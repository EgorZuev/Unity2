using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(0, -1 * _speed * Time.deltaTime, 0);
    }
}
