using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connections:MonoBehaviour
{
    public string connectionName;
    [TextArea]
    public string description;

    public Locations location;

    public bool connectionEnabled=true;
}
