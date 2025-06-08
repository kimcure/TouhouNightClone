using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveDirection { get; private set; }
    public bool IsFocus { get; private set; }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        MoveDirection = new Vector2(x, y).normalized;

        IsFocus = Input.GetButton("Focus");
    }
}
