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
            Debug.LogWarning("총알 프리팹 또는 스폰 위치가 지정되지 않았습니다.");
            return;
        }

        GameObject bullet = PoolManager.Instance.Spawn("PlayerBullet", bulletSpawnPoint.position, Quaternion.identity);
        if (bullet == null)
        {
            Debug.LogError("풀에서 탄환을 가져오지 못했습니다.");
        }
    }
}
