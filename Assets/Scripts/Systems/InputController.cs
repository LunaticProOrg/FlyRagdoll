using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : IInputable, IUpdatable
{
    private float horizontalInput;

    private Vector2 started, current;

    public InputController()
    {
        horizontalInput = 0f;

        started = Vector2.zero;
        current = Vector2.zero;
    }

    public float GetInput() => horizontalInput;


    public void Update()
    {
        var horizontal = 0f;

        if(Input.GetMouseButtonDown(0))
        {
            started = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0))
        {
            current = Input.mousePosition;
            horizontal = (current - started).normalized.x;
            started = Input.mousePosition;
        }

        horizontalInput = horizontal;
    }
}
