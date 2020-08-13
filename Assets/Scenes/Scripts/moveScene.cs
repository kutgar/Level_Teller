using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveScene : MonoBehaviour
{
/// <summary>
/// load scene, obsolote 
/// </summary>
/// <param name="sceneNumber"></param>
    public void loadScene(string sceneNumber)
    {
        SceneManager.LoadScene( sceneNumber);
    }
}
