using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyAgent0 : StoryAgent
{
  
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
    /// situation controller
    /// </summary>
    /// <param name="situation"></param>
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
                Debug.Log(getCurrentNode().text);
                break;
        }
    }
   
}
