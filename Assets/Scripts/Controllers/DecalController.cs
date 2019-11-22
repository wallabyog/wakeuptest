using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalController : BaseGameObject
{
    [SerializeField] private ParticleSystem _vfx;

    private void OnEnable()
    {
        _vfx.Play();

        Call(1f, () => ObjectPool.Instance.Recycle(ThisGameObject));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
