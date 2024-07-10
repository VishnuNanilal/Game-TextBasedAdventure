using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    [TextArea]
    public string description;

    public bool playerCanTake;
    public bool itemEnabled=true;

    public Item targetItem;

    public Interations[] interactions;

    public bool playerCanTalkTo=false;

    public bool playerCanGiveTo=false;

    public bool playerCanRead;

    public bool InteractWith(GameController controller,string actionKeyword,string noun="")
    {
        foreach(Interations interaction in interactions)
        {
            if(interaction.action.keyword==actionKeyword)
            {   
                if(noun!=""&&noun.ToLower()!=interaction.textMatch.ToLower())
                    continue;
                foreach(Item disableitem in interaction.itemsToEnable)
                    disableitem.itemEnabled=false;

                
                foreach(Item enableitem in interaction.itemsToEnable)
                    enableitem.itemEnabled=true;
                
                foreach(Connections disableConnection in interaction.connectionsToDisable)
                    disableConnection.connectionEnabled=false;
                
                foreach(Connections enableConnection in interaction.connectionsToEnable)
                    enableConnection.connectionEnabled=true;
                
                if(interaction.teleportLocation!=null)
                {
                    controller.player.Teleport(controller,interaction.teleportLocation);
                }

                controller.currentText.text=interaction.response;
                controller.DisplayLocation(true);
                    
                return true;
            }
        }
        return false;
    }
}
