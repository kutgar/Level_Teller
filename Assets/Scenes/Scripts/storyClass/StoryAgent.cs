using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryAgent : MonoBehaviour
{
    public const string storyControllerName = "storyController";
    private static bool created = false;
    private StoryController storyController;
    
    // Start is called before the first frame update
    void Start()
    {
        string situation = "";
        //  manageSingleController();

        storyController = GameObject.Find(storyControllerName).GetComponent<StoryController>();
        storyController.onStoryScene += onStorySceneChange;
        situation = storyController.currentdScene;
        getCurrentSituation(situation);
    }
    public void onStorySceneChange(string situation)
    {
        getCurrentSituation(situation);
    }
        // Update is called once per frame
        void Update()
    {
        
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
    private int getCurrentSituation(string situation)
    {
        int situationId = 0;
        
        situation = situation.Split(storyController.flagSperateTagScenceAndIncident)[1];//get only scene number
        int.TryParse(situation,out situationId);
        return situationId;
    }
}
