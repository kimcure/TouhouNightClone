using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pattern", menuName = "BulletPattern/Basic")]
public class BulletPattern : ScriptableObject
{
    public float fireInterval = 1f;
    public int bulletCount = 5;
    public float angleSpread = 60f;
    public float bulletSpeed = 5f;
    public GameObject bulletPrefab;

    public virtual void Fire(Transform origin)
    {
        float angleStep = angleSpread / (bulletCount - 1);
        float startAngle = -angleSpread / 2f;

        for (int i = 0; i < bulletCount; i++)
        { 
            float angle = startAngle + angleStep * i;
            float rad = angle * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

            GameObject bullet = PoolManager.Instance.Spawn(bulletPrefab.name, origin.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
        }
    }
}
