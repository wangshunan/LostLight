using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public abstract class ActBase {

    public enum ActionType
    {
        ActAnimation,
        ActChangeScene,
        ActDestroy,
        ActGrab,
        ActVisible,
        ActWarp,
        ActOutline,
        ActSendMessage,
        ActRelease,
    }

    [Serializable]
    public struct ActionParam
    {
        [NonSerialized]
        public GameObject self;
        public GameObject target;
        public string param;
        public float delay;
        public ActBase.ActionType type;
    }

    public abstract void Action(ActionParam param);

    static Dictionary<ActionType, ActBase> actions = new Dictionary<ActionType, ActBase>();

    static public ActBase GetAction(ActionType type)
    {
        if (actions.ContainsKey(type))
        {
            return actions[type];
        }
        else
        {
            string str = Enum.GetName(typeof(ActionType), type);
            ActBase act = Activator.CreateInstance(Type.GetType(str)) as ActBase;
            if (act != null)
            {
                actions.Add(type, act);
                return act;
            }
        }

        return null;
    }
}
