using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{   
    public string locationName;
    [TextArea]
    public string description;

    public Connections[] connections;
    public List<Item> items=new List<Item>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetItemText()
    {
        bool first=true;
        if(items.Count==0) 
            return " ";

        string result="You see";   
        foreach(Item item in items)
        {
            if(!first) result+=" and";

            result+=" "+item.description; 
            first=false;
        }
        result+="\n";
        return result;       
    }

    public string ReturnConnections()
    {
        
        string result="";
       foreach(Connections connections in connections)
        {
            if(connections.connectionEnabled)
            {
                result+=connections.description+"\n";
            }
        }

        return result;
    }

    public bool HasItems(Item itemToCheck)
    {
       foreach(Item item in items)
        {
            if(item==itemToCheck&&item.itemEnabled)
                return true;
        }
    return false;
    }

    public Connections GetConnections(string connectionNoun)
    {
        foreach(Connections connections in connections)
        {
            if(connections.connectionName.ToLower()==connectionNoun.ToLower())
            {
                return connections;
            }
        }
        return null;
    }
    
}
