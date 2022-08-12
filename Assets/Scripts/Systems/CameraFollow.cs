using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : IFixedUpdatable
{
    private readonly Transform camera;
    private readonly Transform target;
    private readonly CameraFollowConfig config;
    private Vector3 wantedPosition;
    private Vector3 offset;

    public CameraFollow(Transform camera, Transform target, CameraFollowConfig config)
    {
        this.camera = camera;
        this.target = target;
        this.config = config;

        offset = camera.position - target.position;
    }

    public void FixedUpdate()
    {
        wantedPosition = target.position + offset;

        var x = Mathf.Lerp(camera.position.x, wantedPosition.x, config.Height_Speed * Time.deltaTime);
        var y = Mathf.Lerp(camera.position.y, wantedPosition.y, config.Damping * Time.deltaTime);
        var z = Mathf.Lerp(camera.position.z, wantedPosition.z, config.Damping * Time.deltaTime);

        camera.position = new Vector3(x, y, z);
    }
}
