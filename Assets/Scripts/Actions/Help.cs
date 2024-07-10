using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Actions/Help")]
public class Help : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        controller.currentText.text="Type a verb followed by a noun. eg:\"go North\"";
        controller.currentText.text+="\nAllowed verbs : Go, Examine, Get, Use, Inventory,TalkTo, Say, Give, Read, Help";
    }
}
