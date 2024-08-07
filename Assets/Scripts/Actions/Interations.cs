﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interations 
{
    public Action action;

    [TextArea]
    public string response;
    public string textMatch;

    public List<Item> itemsToEnable= new List<Item>();
    public List<Item> itemsToDisable= new List<Item>();

    public List<Connections> connectionsToEnable= new List<Connections>();
    public List<Connections> connectionsToDisable= new List<Connections>();

    public Locations teleportLocation=null;
}
