using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueObject;

public class StoryAgent : MonoBehaviour
{
    public const string storyControllerName = "storyController";
    private static bool created = false;
    public StoryController storyController;
    
 
    /// <summary>
    /// initialize the agent 
    /// </summary>
    public void intializeAgent()
    {
        string situation = "";
        storyController = GameObject.Find(storyControllerName).GetComponent<StoryController>();
        storyController.onStoryScene += onStorySceneChange;
        situation = storyController.currentdScene;
      //  getCurrentSituation(situation);
        onStorySceneChange(situation);
    }
    /// <summary>
    /// when story node change
    /// </summary>
    /// <param name="situation"> the sitution scene.incident</param>
    public void onStorySceneChange(string situation)
    {
        Debug.Log(situation);
       situationChange(getCurrentSituation(situation));
    }
    /// <summary>
    /// change the sitution
    /// need override 
    /// </summary>
    /// <param name="situation"></param>
    public virtual void situationChange(int situation) {
        Debug.Log("situation has change");
        switch (situation)
        {
            case 0:
                Debug.Log("0");
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// only one story controller 
    /// </summary>
    void manageSingleController()
    {
        // Ensure the script is not deleted while loading.
        if (!created)
        {
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    /// <summary>
    /// get current sitution Id
    /// </summary>
    /// <param name="situation"></param>
    /// <returns>sitution Id</returns>
    private int getCurrentSituation(string situation)
    {
        int situationId = 0;
        situation = situation.Split(storyController.flagSperateTagScenceAndIncident)[1];//get only scene number
        int.TryParse(situation,out situationId);
        return situationId;
    }
    /// <summary>
    /// get current node
    /// </summary>
    /// <returns></returns>
    public Node getCurrentNode()
    {
        return storyController.currentNode;
    }
}
