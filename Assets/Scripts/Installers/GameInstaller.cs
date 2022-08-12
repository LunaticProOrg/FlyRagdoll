using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller<GameInstaller>
{
    [SerializeField] private Camera _camera;
    [SerializeField] private MoveComponent moveComponent;
    [SerializeField] private MovementConfig config;
    [SerializeField] private CameraFollowConfig cameraConfig;

    public override void InstallBindings()
    {
        var updatables = new List<IUpdatable>();
        var fixedUpdatables = new List<IFixedUpdatable>();

        var inputController = new InputController();
        var moveController = new MoveController(moveComponent.Rigidbody, config, inputController);
        var cameraController = new CameraFollow(_camera.transform, moveComponent.transform, cameraConfig);

        updatables.Add(inputController);
        updatables.Add(moveController);
        fixedUpdatables.Add(moveController);
        fixedUpdatables.Add(cameraController);

        Container.BindInterfacesAndSelfTo<InputController>().FromInstance(inputController).AsSingle();
        Container.BindInterfacesAndSelfTo<MoveController>().FromInstance(moveController).AsSingle();
        Container.BindInterfacesAndSelfTo<CameraFollow>().FromInstance(cameraController).AsSingle();

        Container.Bind<IUpdatable[]>().FromInstance(updatables.ToArray()).AsSingle();
        Container.Bind<IFixedUpdatable[]>().FromInstance(fixedUpdatables.ToArray()).AsSingle();

        Container.Bind<MovementConfig>().FromInstance(config).AsSingle();
    }
}
