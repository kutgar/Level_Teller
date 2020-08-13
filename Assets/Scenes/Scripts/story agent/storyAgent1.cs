using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storyAgent1 : StoryAgent
{
    public Text Username_field;
    // Start is called before the first frame update
    void Start()
    {
        intializeAgent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// sitution contorller
    /// </summary>
    /// <param name="situation"> sitution ID</param>
    public override void situationChange(int situation)
    {
        Debug.Log("situation has change");
        switch (situation)
        {
            case 0:
                Debug.Log(getCurrentNode().text);
                break;
            case 1:
                Debug.Log(getCurrentNode().text);
                break;
            default:
                Debug.Log("defualt");
                Debug.Log(getCurrentNode().text);
                break;
        }
    }
    /// <summary>
    /// enter name handler
    /// </summary>
    public void enterName()
    {
        string name;
        name = Username_field.text.ToString();
        //as joke in first time say the username has taken
        if (storyController.currentNode.responses.Count == 1)
            storyController.OnNodeSelected(0);
        else
        {
            if(name=="uriel")//uriel ending
                storyController.OnNodeSelected("urielEnd");
            if (name == "doron")//doron ending
                storyController.OnNodeSelected("doronEnd");
            else
            {//regularPath
                storyController.name = name;
            storyController.OnNodeSelected(0);
            }
        }
    }
}
