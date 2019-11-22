using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMarkView : BaseGameObject
{
    private IEntityData _data;
    // Start is called before the first frame update
    void Start()
    {
        _data = ThisTransform.root.GetComponent<IEntityData>();
        Broadcaster.Instance.AddListener(BroadcasterEvents.TargetFounded, OnTargetFounded);
    }

    private void OnTargetFounded(object[] obj)
    {
        var target = (IEntityData)obj[0];

        ThisGameObject.SetActive(target == _data);
    }

    private void OnDestroy()
    {
        Broadcaster.Instance.RemoveListener(BroadcasterEvents.TargetFounded, OnTargetFounded);
    }
    
}
