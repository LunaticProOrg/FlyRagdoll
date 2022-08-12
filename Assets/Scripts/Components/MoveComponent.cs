using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    public Rigidbody Rigidbody { get { return GetComponent<Rigidbody>(); } }

    private BodyComponent[] bodies;

    private MovementConfig config;

    private bool canJump = true;


    [Zenject.Inject]
    private void Construct(MovementConfig config) => this.config = config;

    private void Awake() => bodies = GetComponentsInChildren<BodyComponent>();

    private void Start()
    {
        foreach(var item in bodies)
            item.OnBodyEnterCollision += Item_OnBodyEnterCollision;
    }

    private void Item_OnBodyEnterCollision(Collision other)
    {
        bool isCollision = config.JumpLayer.value == (config.JumpLayer | (1 << other.gameObject.layer));

        if(isCollision && canJump)
        {
            canJump = false;

            var velocity = Rigidbody.velocity;
            velocity.y += config.JumpForce;
            Rigidbody.velocity = velocity;

            StartCoroutine(LastJumpOffset());
        }
    }

    private void OnDestroy()
    {
        foreach(var item in bodies)
            item.OnBodyEnterCollision -= Item_OnBodyEnterCollision;
    }

    private IEnumerator LastJumpOffset()
    {
        yield return new WaitForSeconds(.5f);
        canJump = true;
    }
}
