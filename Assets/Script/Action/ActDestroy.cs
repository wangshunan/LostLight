using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class ActDestroy : ActBase
{
    public override void Action(ActionParam param)
    {
        GameObject.Destroy(param.target);
    }
}
