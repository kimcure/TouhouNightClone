using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 4f;
    public float lifeTime = 4f;

    private float timer;
    private const string poolKey = "EnemyBullet";

    private void OnEnable()
    {
        timer = 0f;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer >= lifeTime)
            PoolManager.Instance.Despawn(poolKey, gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // TODO: 플레이어에게 데미지 추가
            PoolManager.Instance.Despawn(poolKey, gameObject);
        }
    }
}
