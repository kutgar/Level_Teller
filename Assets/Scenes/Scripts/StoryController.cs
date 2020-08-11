using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueObject;
   
public class StoryController : MonoBehaviour
{
    DialogueController controller;
    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<DialogueController>();
       controller.onEnteredNode += OnNodeEntered;
        controller.InitializeDialogue();
       // OnNodeSelected(1);
    }

    
    public void OnNodeEntered(Node newNode)
    {

        for (int i = newNode.responses.Count - 1; i >= 0; i--)
        {
            int currentChoiceIndex = i;
            var response = newNode.responses[i];
            Debug.Log(newNode.title);
            Debug.Log(newNode.text);
         
            //  var responceButton = Instantiate(prefab_btnResponse, parentOfResponses);
            //  responceButton.GetComponentInChildren<SlowTyper>().Begin(response.displayText);
            //    responceButton.onClick.AddListener(delegate { OnNodeSelected(currentChoiceIndex); });
        }
    }
    private void OnNodeSelected(int indexChosen)
    {
        Debug.Log("Chose: " + indexChosen);
        if (!controller.GetCurrentNode().IsEndNode())
            controller.ChooseResponse(indexChosen);
    }
}
