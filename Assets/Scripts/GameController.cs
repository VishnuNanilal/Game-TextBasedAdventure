using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{   
    public Player player;

    public InputField userInput;
    public Text currentText;
    public Text historyText;

    [TextArea]
    public string introText;

    public Action[] actions;

    void Start()
    {
        historyText.text=introText;
        DisplayLocation();
        userInput.text="";
        userInput.ActivateInputField();
    }

    void Update()
    {   
        
        
    }

    public void DisplayLocation(bool additive=false)
    {
        string description= "\n"+player.currentLocation.description+"\n";
        description+=player.currentLocation.ReturnConnections()+"\n";
        description+=player.currentLocation.GetItemText();
        if(additive)
            currentText.text=currentText.text+"\n" +description;
        else
            currentText.text=description;
    }

    public void TextEntered()
    {
        if (string.IsNullOrWhiteSpace(userInput.text))
        {
            return;
        }
        LogCurrentText();
        ProcessInput(userInput.text);
        userInput.ActivateInputField();
    }

    public void LogCurrentText()
    {   
        historyText.text+="\n\n";
        historyText.text+=currentText.text;

        historyText.text+="\n\n";
        historyText.text+="<color=#aaccaaff>"+userInput.text+"</color>";
    }

    void ProcessInput(string input)
    {
        input=input.ToLower();
        
        char[] delimiter={' '};
        string[] seperatedWords=input.Split(delimiter);

        foreach(Action action in actions)
        {
            if(action.keyword.ToLower()==seperatedWords[0])
            {
                if(seperatedWords.Length>1)
                {
                    action.RespondToInput(this, seperatedWords[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
            return;
            }
        }

        currentText.text="Nothing Happens!!!";
    }
    
}
