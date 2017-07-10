using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class ActAnimation : ActBase
{
    public override void Action(ActionParam param)
    {
        if (param.target != null)
        {
            Animation anim = param.target.GetComponent<Animation>();
            if (anim != null)
            {
                anim.Play();
                return;
            }
        }

        Debug.Log("ActAnimation Param Error: " + param);
    }
}
