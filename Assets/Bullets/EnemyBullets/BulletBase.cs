using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [Header("공통 속성")]
    public float speed = 5f;
    public float lifeTime = 5f;

    protected float timeElapsed = 0f;

    private void OnEnable()
    {
        timeElapsed = 0f;
    }

    protected virtual void Update()
    {
        timeElapsed = Time.deltaTime;
        if (timeElapsed >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
