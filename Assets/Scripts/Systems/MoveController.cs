using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : IFixedUpdatable, IUpdatable, IBoostApplyable
{
    private readonly Rigidbody _body;
    private readonly IInputable _inputable;

    private MovementConfig _config;

    private float moveStateBase = 1f;
    private float currentMoveState = 1f;

    public MoveController(Rigidbody body, MovementConfig config, IInputable inputable)
    {
        _body = body;
        _inputable = inputable;
        _config = config;
    }

    public void FixedUpdate()
    {
        if(_config == null) return;

        var horizontal = _inputable.GetInput();
        var movementForce = horizontal * _config.HorizontalForce;
        _body.AddForce(Vector3.forward * _config.ForwardForce * currentMoveState, _config.ForwardForceMode);

        var velocity = _body.velocity;

        velocity.x = Mathf.Clamp(movementForce, -_config.HorizontalForce, _config.HorizontalForce);
        velocity.z = Mathf.Clamp(velocity.z, 0f, _config.ForwardForce * currentMoveState);

        _body.velocity = velocity;
    }

    public void Update()
    {
        _body.transform.position = new Vector3
        {
            x = Mathf.Clamp(_body.transform.position.x, _config.ClampHorizontalMin, _config.ClampHorizontalMax),
            y = _body.transform.position.y,
            z = _body.transform.position.z
        };
    }

    public void OnBoostStart(float amount)
    {
        currentMoveState = amount;
    }

    public void OnBoostEnd()
    {
        currentMoveState = moveStateBase;
    }
}
