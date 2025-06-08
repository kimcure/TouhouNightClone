using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBullet : BulletBase
{
    public float rotationSpeed = 180f;

    protected override void Update()
    {
        base.Update();

        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
