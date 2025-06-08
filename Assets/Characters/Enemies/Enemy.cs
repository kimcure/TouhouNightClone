using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed = 1.5f;
    public int maxHP = 5;

    [SerializeField] private GameObject explosionEffectPrefab;
    [SerializeField] private int scoreValue = 100;

    private int currentHP;

    private void OnEnable()
    {
        MoveDownward();
    }

    private void MoveDownward()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (explosionEffectPrefab != null)
        {
            GameObject fx = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity, GameObject.Find("FXContainer").transform);
        }

        ScoreManager.Instance.AddScore(scoreValue);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            TakeDamage(1);
        }
    }
}
