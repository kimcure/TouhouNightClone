using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        ps.Play();

        Invoke(nameof(DestroySelf), ps.main.duration);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
