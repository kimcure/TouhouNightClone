using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float slowMoveSpeed = 2f;

    private PlayerInput input;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 dir = input.MoveDirection;
        float speed = input.IsFocus ? slowMoveSpeed : moveSpeed;

        transform.Translate(dir * speed * Time.deltaTime);
    }
}
