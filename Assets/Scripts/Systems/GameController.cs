using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class GameController : MonoBehaviour
{
    private IInitializable[] initializables;
    private IUpdatable[] updatables;
    private IFixedUpdatable[] fixedUpdatables;

    [Inject]
    public void Construct(IInitializable[] initializables, IUpdatable[] updatables, IFixedUpdatable[] fixedUpdatables)
    {
        this.initializables = initializables;
        this.updatables = updatables;
        this.fixedUpdatables = fixedUpdatables;
    }

    private void Awake()
    {
        if(initializables == null) return;

        for(int i = 0; i < initializables.Length; i++)
        {
            initializables[i].Initialize(true);
        }
    }

    private void Update()
    {
        if(updatables == null) return;

        for(int i = 0; i < updatables.Length; i++)
        {
            updatables[i].Update();
        }
    }

    private void FixedUpdate()
    {
        if(fixedUpdatables == null) return;

        for(int i = 0; i < fixedUpdatables.Length; i++)
        {
            fixedUpdatables[i].FixedUpdate();
        }
    }
}