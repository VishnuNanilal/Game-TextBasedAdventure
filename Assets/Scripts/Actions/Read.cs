using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
         if(ReadItems(controller,controller.player.currentLocation.items,noun))
        {
            return;
        }

        if(ReadItems(controller,controller.player.inventory,noun))
        {
            return;
        }

        controller.currentText.text="The "+noun+" cannot be read";
        //controller.currentText.text="The "+noun+" does nothing";
        return;
    }

    private bool ReadItems(GameController controller,List<Item> items,string noun)
    {
        foreach(Item item in items)
        {
            if(item.itemName==noun)
            {   if(controller.player.CanReadItem(controller, item))
                {
                    if(item.InteractWith(controller,"read"))
                    {
                        return true;
                    }
                    //controller.currentText.text="The "+noun+" cannot be read";     
                    //return true;
                }           
            }
        }
    return false;
    }
}
