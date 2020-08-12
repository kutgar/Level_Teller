using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueObject;

public class DialogueController : MonoBehaviour
{
    [SerializeField] TextAsset twineText;
    Dialogue curDialogue;
    Node curNode;

    public delegate void NodeEnteredHandler(Node node);
    public event NodeEnteredHandler onEnteredNode;

    /// <summary>
    /// get current node
    /// </summary>
    /// <returns>current node</returns>
    public Node GetCurrentNode()
    {
        return curNode;
    }

    /// <summary>
    /// initialize  dialogue with twine text
    /// </summary>
    public void InitializeDialogue()
    { 
        curDialogue = new Dialogue(twineText);
        curNode = curDialogue.GetStartNode();
        onEnteredNode(curNode);
    }
    /// <summary>
    /// set the desired dialog
    /// </summary>
    /// <param name="titleNameNode"></param>
    public void setCurrentNode(string titleNameNode)
    {
        curNode = curDialogue.GetNode(titleNameNode);
        onEnteredNode(curNode);
    }
    /// <summary>
    /// get current responses
    /// </summary>
    /// <returns> curernt responses</returns>
    public List<Response> GetCurrentResponses()
    {
        return curNode.responses;
    }

    /// <summary>
    /// choose response by index 
    /// </summary>
    /// <param name="responseIndex"></param>
    public void ChooseResponse(int responseIndex)
    {
        string nextNodeID = curNode.responses[responseIndex].destinationNode;
        Node nextNode = curDialogue.GetNode(nextNodeID);
        curNode = nextNode;
        onEnteredNode(nextNode);
    }
   
    
   
}

