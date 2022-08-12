using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostComponent : MonoBehaviour
{
    public LayerMask boostMask;
    private BodyComponent[] bodies;

    IBoostApplyable applyable;

    [Zenject.Inject]
    private void Construct(IBoostApplyable applyable) => this.applyable = applyable;

    private void Awake() => bodies = GetComponentsInChildren<BodyComponent>();
    private void Start()
    {
        foreach(var item in bodies)
            item.OnBodyEnterTrigger += Item_OnBodyEnterCollision;
    }

    private void Item_OnBodyEnterCollision(Collider other)
    {
        bool isCollision = boostMask.value == (boostMask | (1 << other.gameObject.layer));

        if(isCollision && other.gameObject.TryGetComponent<Boost>(out var boost))
        {
            applyable.OnBoostStart(boost.GetAmount());

            StartCoroutine(Boost(boost.GetWorkTime()));

            other.gameObject.SetActive(false);
        }
    }

    private IEnumerator Boost(float workTime)
    {
        yield return new WaitForSeconds(workTime);

        applyable.OnBoostEnd();
    }

    private void OnDestroy()
    {
        foreach(var item in bodies)
            item.OnBodyEnterTrigger -= Item_OnBodyEnterCollision;
    }
}
