using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using UniRx.Triggers;

public class InteractableObject : MonoBehaviour
{
    public virtual void Act(List<ActBase.ActionParam> actions, GameObject target)
    {
        actions.ForEach(a =>
        {
            ActBase act = ActBase.GetAction(a.type);
            if (act != null)
            {
                a.target = (a.target) ? a.target : target;
                a.self = gameObject;
                if (a.delay > 0)
                {
                    Observable.Timer(TimeSpan.FromSeconds(a.delay)).Subscribe(_ => act.Action(a)).AddTo(this);
                }
                else
                {
                    act.Action(a);
                }
            }
        });
    }
}
