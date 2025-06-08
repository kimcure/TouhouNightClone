using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.15f;

    private float fireTImer;

    void Update()
    {
        fireTImer += Time.deltaTime;

        if (Input.GetButton("Fire1") && fireTImer >= fireRate)
        {
            Fire();
            fireTImer = 0f;
        }
    }

    private void Fire()
    {
        if (bulletPrefab == null || bulletSpawnPoint == null)
        {
            Debug.LogWarning("�Ѿ� ������ �Ǵ� ���� ��ġ�� �������� �ʾҽ��ϴ�.");
            return;
        }

        GameObject bullet = PoolManager.Instance.Spawn("PlayerBullet", bulletSpawnPoint.position, Quaternion.identity);
        if (bullet == null)
        {
            Debug.LogError("Ǯ���� źȯ�� �������� ���߽��ϴ�.");
        }
    }
}
