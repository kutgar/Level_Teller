using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObject : MonoBehaviour
{
    //key name for start node 
    private const string keyStartNode = "START";
    private const string keyEndNode = "END";

    /// <summary>
    /// response class
    /// </summary>
    public struct Response
    {
        public string displayText;
        public string destinationNode;

        /// <summary>
        /// consructot for response 
        /// </summary>
        /// <param name="display">display text</param>
        /// <param name="destination">next hop to node </param>
        public Response(string display, string destination)
        {
            displayText = display;
            destinationNode = destination;
        }
    }
    
    public class Node
    {
        public string title;
        public string text;
        public List<string> tags;
        public List<Response> responses;


        /// <summary>
        /// if we got to end node
        /// </summary>
        /// <returns>
        /// true if we in end of the node 
        /// false not in the end
        /// </returns>
        internal bool IsEndNode()
        {
            return tags.Contains(keyEndNode);
        }

       /// <summary>
       /// overide to string
       /// </summary>
       /// <returns>
       /// string with info of j
       /// </returns>
        public override string ToString()
        {
            return string.Format("Node {  Title: '%s', Text: '%s'}", title, text);
        }

    }

    public class Dialogue
    {
        string title;
        Dictionary<string, Node> nodes;
        string titleOfStartNode;
        public Dialogue(TextAsset twineText)
        {

            nodes = new Dictionary<string, Node>();

            ParseTwineText(twineText);
        }

        public Node GetNode(string nodeTitle)
        {
            return nodes[nodeTitle];
        }

        public Node GetStartNode()
        {
            UnityEngine.Assertions.Assert.IsNotNull(titleOfStartNode);
            return nodes[titleOfStartNode];
        }

        public void ParseTwineText(TextAsset twineText)
        {
            string text = twineText.text;

            string[] nodeData = text.Split(new string[] { "::" }, StringSplitOptions.None);

            const int kIndexOfContentStart = 4;
            for (int i = 0; i < nodeData.Length; i++)
            {
                if (i < kIndexOfContentStart)
                   continue;

                // Note: tags are optional
                // Normal Format: "NodeTitle [Tags, comma, seperated] \r\n Message Text \r\n [[Response One]] \r\n [[Response Two]]"
                // No-Tag Format: "NodeTitle \r\n Message Text \r\n [[Response One]] \r\n [[Response Two]]"
                string currLineText = nodeData[i];
                bool tagsPresent = currLineText.IndexOf("[") < currLineText.IndexOf("\r\n");
                int endOfFirstLine = currLineText.IndexOf("\r\n");

                int startOfResponses = -1;
                int startOfResponseDestinations = currLineText.IndexOf("[[");
                bool lastNode = (startOfResponseDestinations == -1);
                if (lastNode)
                    startOfResponses = currLineText.Length;
                else
                {
                    // Last new line before "[["
                    startOfResponses = currLineText.Substring(0, startOfResponseDestinations).LastIndexOf("\r\n");
                }

                // Extract Title
                int titleStart = 0;
                int titleEnd = tagsPresent
                    ? currLineText.IndexOf("[")
                    : endOfFirstLine;
                string title = currLineText.Substring(titleStart, titleEnd).Trim();

                // Extract Tags (if any)
                string tags = tagsPresent
                    ? currLineText.Substring(titleEnd + 1, (endOfFirstLine - titleEnd) - 2)
                    : "";

                // Extract Message Text & Responses
                string messsageText = currLineText.Substring(endOfFirstLine, startOfResponses - endOfFirstLine).Trim();
                string responseText = currLineText.Substring(startOfResponses).Trim();

                Node curNode = new Node();
                curNode.title = title;
                curNode.text = messsageText;
                curNode.tags = new List<string>(tags.Split(new string[] { " " }, StringSplitOptions.None));

                if (curNode.tags.Contains(keyStartNode))
                {
                    UnityEngine.Assertions.Assert.IsTrue(null == titleOfStartNode);
                    titleOfStartNode = curNode.title;
                }

                // Note: response messages are optional (if no message then destination is the message)
                // With Message Format: "\r\n Message[[Response One]]"
                // Message-less Format: "\r\n [[Response One]]"
                curNode.responses = new List<Response>();
                if (!lastNode)
                {
                    List<string> responseData = new List<string>(responseText.Split(new string[] { "\r\n" }, StringSplitOptions.None));
                    for (int k = responseData.Count - 1; k >= 0; k--)
                    {
                        string curResponseData = responseData[k];

                        if (string.IsNullOrEmpty(curResponseData))
                        {
                            responseData.RemoveAt(k);
                            continue;
                        }

                        // If message-less, then destination is the message
                        Response curResponse = new Response();
                        int destinationStart = curResponseData.IndexOf("[[");
                        int destinationEnd = curResponseData.IndexOf("]]");
                        string destination = curResponseData.Substring(destinationStart + 2, (destinationEnd - destinationStart) - 2);

                        if (destination.Contains("|") == true)
                        {
                            curResponse.destinationNode = destination.Split('|')[1] + "";
                            destination = destination.Split('|')[0] + "";
                        }
                        else
                        curResponse.destinationNode = destination;

                        //curResponse.destinationNode = destination;
                        if (destinationStart == 0)
                            curResponse.displayText = destination;
                        else
                            curResponse.displayText = curResponseData.Substring(0, destinationStart);
                        curNode.responses.Add(curResponse);
                    }
                }


                nodes[curNode.title] = curNode;
            }
        }
    }
}
