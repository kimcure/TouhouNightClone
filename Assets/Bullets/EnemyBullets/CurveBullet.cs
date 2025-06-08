using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBullet : BulletBase
{
    public float curveStrength = 2f;

    private Vector3 direction;
    private float curveOffset = 0f;

    private void Start()
    {
        direction = transform.up;
    }

    protected override void Update()
    {
        base.Update();

        curveOffset += Time.deltaTime * curveStrength;
        Vector3 curveDirection = direction + transform.right * Mathf.Sin(curveOffset);
        transform.position += curveDirection.normalized * speed * Time.deltaTime;
    }
}
