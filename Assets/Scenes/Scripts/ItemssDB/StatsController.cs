using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.HeroEditor4D.FantasyInventory.Scripts;

public class StatsController : MonoBehaviour
{

    public Text statsText;
 /// <summary>
 /// need to expand, for testing 
 /// </summary>
    void Start()
    {
        ItemCollection itemCol =this.GetComponent<ItemCollection>();
        
        statsText.text= itemCol.getStats("")+"";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
