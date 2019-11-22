using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGameObject : MonoBehaviour
{
    private Transform _thisTransform;
    public Transform ThisTransform => _thisTransform == null ? _thisTransform = transform : _thisTransform;
    
    private GameObject _thisGameObject;
    public GameObject ThisGameObject => _thisGameObject == null ? _thisGameObject = gameObject : _thisGameObject;

    protected Coroutine Call(float time, Action a)
    {
        return StartCoroutine(CallCoroutine(time, a));
    }

    IEnumerator CallCoroutine(float time, Action a)
    {
        yield return new WaitForSeconds(time);
        
        a?.Invoke();
    }
}
