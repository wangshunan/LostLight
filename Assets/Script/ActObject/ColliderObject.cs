using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class ColliderObject : TriggerObject
{
    [SerializeField]
    List<ActBase.ActionParam> enterActs = new List<ActBase.ActionParam>();
    [SerializeField]
    List<ActBase.ActionParam> leaveActs = new List<ActBase.ActionParam>();
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private string constraince;

    protected virtual void OnCollisionEnter(Collision coll)
    {
        if (obj != null)
        {
            return;
        }

        if (constraince != "")
        {
            DataHolder data = coll.gameObject.GetComponent<DataHolder>();
            if (data == null || data.Type != constraince)
            {
                return;
            }
        }

        Debug.Log( gameObject.name + " CollisionEnter " + coll.gameObject.name );

        obj = coll.gameObject;
        Act(enterActs, target == null ? coll.gameObject : target);
    }

    protected virtual void OnTriggerEnter(Collider coll)
    {
        if (obj != null)
        {
            return;
        }

        if (constraince != "")
        {
            DataHolder data = coll.gameObject.GetComponent<DataHolder>();
            if (data == null || data.Type != constraince)
            {
                return;
            }
        }

        Debug.Log( gameObject.name + " TriggerEnter " + coll.gameObject.name );

        obj = coll.gameObject;
        Act(enterActs, target == null ? coll.gameObject : target);
    }

    protected virtual void OnCollisionExit(Collision coll)
    {
        if (obj == coll.gameObject)
        {
            Debug.Log( gameObject.name + " CollisionExit " + coll.gameObject.name );

            obj = null;

            Act(leaveActs, target == null ? coll.gameObject : target);
        }
    }

    protected virtual void OnTriggerExit(Collider coll)
    {
        if (obj == coll.gameObject)
        {
            Debug.Log( gameObject.name + " TriggerExit " + coll.gameObject.name );

            obj = null;

            Act(leaveActs, target == null ? coll.gameObject : target);
        }
    }
}