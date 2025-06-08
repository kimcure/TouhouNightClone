using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxVisibility : MonoBehaviour
{
    private SpriteRenderer sr;
    private Transform playerTransform;
    private PlayerInput input;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        playerTransform = transform.parent;
        input = playerTransform.GetComponent<PlayerInput>();
    }

    private void Update()
    {
        sr.enabled = input.IsFocus;
    }
}
