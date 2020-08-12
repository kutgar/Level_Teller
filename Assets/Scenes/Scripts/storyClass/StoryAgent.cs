using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryAgent : MonoBehaviour
{
   public GameObject storyManager;
    private static bool created = false;
    
    // Start is called before the first frame update
    void awake()
    {
        manageSingleController();
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
}
