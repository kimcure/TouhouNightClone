using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Fire Settings")]
    public float fireInterval = 1.2f;
    public Transform firePoint;

    private float fireTImer;
    private const string poolKey = "EnemyBullet";

    private void Update()
    {
        fireTImer += Time.deltaTime;

        if (fireTImer >=  fireInterval)
        {
            Fire();
            fireTImer = 0f;
        }
    }

    private void Fire()
    {
        if (firePoint == null)
        {
            Debug.LogWarning("FirePoint가 설정되지 않음");
            return;
        }

        GameObject bullet = PoolManager.Instance.Spawn(poolKey, firePoint.position, Quaternion.identity);
        if (bullet == null)
        {
            Debug.LogError("EnemyBullet 풀에서 탄환을 가져오지 못함");
        }
    }
}
