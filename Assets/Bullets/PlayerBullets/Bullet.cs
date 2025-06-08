using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 10f;
    public float lifeTime = 4f;

    private float timer;
    private const string poolKey = "PlayerBullet";

    private void OnEnable()
    {
        timer = 0f;
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= lifeTime) {
            PoolManager.Instance.Despawn(poolKey, gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            PoolManager.Instance.Despawn(poolKey, gameObject);
        }
    }
}
