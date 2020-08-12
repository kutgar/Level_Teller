using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueObject;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    DialogueController controller;
    public int delayScene;
    const string flagTagScene = "scene-";
    const string flagSperateTagScenceAndIncident = ".";
    private static bool created = false;
    private static string currentdScene = "";

    // Start is called before the first frame update
    void Start()
    {
        manageSingleController();
        controller = GetComponent<DialogueController>();
        controller.onEnteredNode += OnNodeEntered;
        controller.InitializeDialogue();
   
    }
    /// <summary>
    /// only one story controller 
    /// </summary>
    void manageSingleController()
    {
        // Ensure the script is not deleted while loading.
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    /// <summary>
    /// when new node has been entered 
    /// </summary>
    /// <param name="newNode"></param>
    public void OnNodeEntered(Node newNode)
    {
        string tag;
        for (int i = newNode.responses.Count - 1; i >= 0; i--)
        {
            int currentChoiceIndex = i;
            var response = newNode.responses[i];
            Debug.Log(newNode.ToString());


            tag = getTags(newNode, getSceneTags)[0];

            Debug.Log(tag);
            tag = tag.Replace(flagTagScene, "");
            currentdScene = tag;
            Debug.Log(tag);
            if (tag.Contains(flagSperateTagScenceAndIncident))
                tag = tag.Substring(0, tag.IndexOf(flagSperateTagScenceAndIncident));//get only scene number
            Debug.Log(tag);
            moveToScene(tag);
            //  var responceButton = Instantiate(prefab_btnResponse, parentOfResponses);
            //  responceButton.GetComponentInChildren<SlowTyper>().Begin(response.displayText);
            //    responceButton.onClick.AddListener(delegate { OnNodeSelected(currentChoiceIndex); });
        }
    }
    /// <summary>
    /// move to scene by number name 
    /// </summary>
    /// <param name="sceneNumber"></param>
    private void moveToScene(int sceneNumber)
    {
        if (sceneNumber == null)
            return;
        if (SceneManager.GetActiveScene().buildIndex!= delayScene + sceneNumber)
          SceneManager.LoadScene(delayScene + sceneNumber);
    }
    /// <summary>
    /// only a numbers should go to load scene
    /// </summary>
    /// <param name="sceneName"></param>
    private void moveToScene(string desireSceneNumber)
    {
        int sceneNumber = 0;
        int.TryParse(desireSceneNumber, out sceneNumber);
        moveToScene(sceneNumber);
    }

    #region tagHandler
    /// <summary>
    /// check if the the string start with 'scene'
    /// </summary>
    /// <param name="tag"> string you want to check</param>
    /// <returns></returns>
    private bool getSceneTags(string tag)
    {
        if (tag.StartsWith(flagTagScene))
            return true;
        else
            return false;
    }
    /// <summary>
    /// delegate for return specific tags
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    delegate bool filterTag(string tag);
    /// <summary>
    /// get tags from a node 
    /// </summary>
    /// <param name="node"></param>
    /// <param name="sort"></param>
    /// <returns>
    /// specifc sort you want to use 
    /// </returns>
    private List<string> getTags(Node node, filterTag sort)
    {
        List<string> tags = new List<string>();
       
        foreach (var tag in node.tags)
        {
            if (sort(tag))
            {
                tags.Add(tag);
            }
        }
        return tags;
    }
    #endregion 

    /// <summary>
    /// choose response 
    /// </summary>
    /// <param name="indexChosen">index of the desire response</param>
    private void OnNodeSelected(int indexChosen)
    {
        Debug.Log("Chose: " + indexChosen);
        if (!controller.GetCurrentNode().IsEndNode())
           controller.ChooseResponse(indexChosen);
    }
    /// <summary>
    /// on selected node by specific search
    /// </summary>
    /// <param name="desireResponse"></param>
    /// <param name="sort"></param>
    private void OnNodeSelected(string desireResponse, filterRespons sort)
    {
        if (!controller.GetCurrentNode().IsEndNode())
            controller.ChooseResponse(getResponse(sort, desireResponse, controller.GetCurrentResponses()));
    }

    #region responseHandler
    /// <summary>
    /// delegate for return specific response
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    delegate bool filterRespons(Response response, string desireResponse);
    /// <summary>
    /// get response from a node 
    /// </summary>
    /// <param name="node"></param>
    /// <param name="sort"></param>
    /// <returns>
    /// specifc responses by display name you want to use 
    /// </returns>
    private int getResponse(filterRespons sort, string desireResponse,List<Response> responses)
    {

        int index = 0;
        for (index = 0; index < responses.Count - 1; index++)
        {
            if (sort(responses[index], desireResponse))
            {
                return index;
            }
        }
        return index;
    }
    /// <summary>
    /// check response by display name
    /// </summary>
    /// <param name="response"></param>
    /// <param name="desireResponse"></param>
    /// <returns>
    /// true - the response we looking
    /// </returns>
    private bool chooseResponseByDisplayName(Response response,string desireResponse)
    {
        if (response.displayText == desireResponse)
            return true;
        else
            return false;
    }
    #endregion 
}
