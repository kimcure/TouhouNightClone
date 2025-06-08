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
            Debug.LogWarning("FirePoint�� �������� ����");
            return;
        }

        GameObject bullet = PoolManager.Instance.Spawn(poolKey, firePoint.position, Quaternion.identity);
        if (bullet == null)
        {
            Debug.LogError("EnemyBullet Ǯ���� źȯ�� �������� ����");
        }
    }
}
