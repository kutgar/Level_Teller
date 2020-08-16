using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.HeroEditor4D.FantasyInventory.Scripts;
using Assets.HeroEditor4D.FantasyInventory.Scripts.Data;
using System.Linq;

public class InitUserItems : MonoBehaviour
{
    public ItemCollection itemCol;
    // Start is called before the first frame update
    void Start()
    {
         itemCol = this.GetComponent<ItemCollection>();
       
        initUserItems(itemCol.UserItems);
        
    }/// <summary>
    /// loop all  the user Items and update stats
    /// </summary>
    /// <param name="UserItems">user items list</param>
    public void initUserItems(List<ItemParams> UserItems)
    {
        foreach (var item in UserItems)
        {
            var weapons = ItemBuild.getItems("dataStats").Items.Where(i => i.Name == item.Id).ToList();
            if (weapons.Count ==0)
                continue;
            item.Strength = weapons[0].Strength;
            item.Hp = weapons[0].Hp;
            item.Shield = weapons[0].Shield;
        }
    }

}
