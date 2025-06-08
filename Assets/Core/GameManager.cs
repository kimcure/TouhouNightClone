using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerBulletPrefab;
    public GameObject enemyBulletPrefab;
    public GameObject enemyBulletCurvePrefab;
    public GameObject enemyBulletSpiralPrefab;
    public GameObject enemyBulletRotatePrefab;
    public GameObject explosionEffectPrefab;

    private void Start()
    {
        PoolManager.Instance.CreatePool("PlayerBullet", playerBulletPrefab, 100);
        PoolManager.Instance.CreatePool("EnemyBullet", enemyBulletPrefab, 100);
        PoolManager.Instance.CreatePool("Bullet_Curve", enemyBulletCurvePrefab, 100);
        PoolManager.Instance.CreatePool("Bullet_Spiral", enemyBulletSpiralPrefab, 100);
        PoolManager.Instance.CreatePool("Bullet_Rotate", enemyBulletRotatePrefab, 100);
        PoolManager.Instance.CreatePool("Explosion", explosionEffectPrefab, 50);
    }
}
