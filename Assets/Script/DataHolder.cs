using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour {

    [SerializeField]
    private string type;
    public string Type { get { return type; } }
}
