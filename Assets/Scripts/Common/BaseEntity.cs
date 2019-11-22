using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : BaseGameObject
{
    private IEntityData _thisEntityData;
    public IEntityData ThisEntity => _thisEntityData ?? (_thisEntityData = ThisTransform.root.GetComponent<IEntityData>());
}
