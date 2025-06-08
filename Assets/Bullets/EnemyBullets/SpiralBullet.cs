using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpiralBullet : BulletBase
{
    public float spiralRadius = 1.5f;
    public float spiralSpeed = 5f;

    private float angle = 0f;
    private Vector3 center;

    private void Start()
    {
        center = transform.position;
    }

    protected override void Update()
    {
        base.Update();

        angle += spiralSpeed * Time.deltaTime;
        float x = Mathf.Cos(angle) * spiralRadius;
        float y = Mathf.Sin(angle) * spiralRadius;
        transform.position = center + new Vector3(x, y, 0);
    }
}
