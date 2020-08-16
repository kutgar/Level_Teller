using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemStats;

public class ItemBuild : MonoBehaviour
{
    const string PATH = "Assets/Scenes/Scripts/ItemssDB";
    // Start is called before the first frame update
    void Start()
    {

      /*  ItemList col = new ItemList();
       
        ItemStats item = new ItemStats();
        item.Name = "BronzePickaxe";
        item.Hp = 3;
        item.Strength = 1;
        item.Shield = 1 ;
        col.Items.Add(item) ;
         item = new ItemStats();
        item.Name = "Honey";
        item.Hp = 0;
        item.Strength = 0;
        item.Shield = 0;
        col.Items.Add(item);
        item = new ItemStats();
        item.Name = "Katana";
        item.Hp = 2;
        item.Strength = 5;
        item.Shield = 1;
        col.Items.Add(item);
        item = new ItemStats();
        item.Name = "ShortSword";
        item.Hp = 2;
        item.Strength = 2;
        item.Shield = 1;
        col.Items.Add(item);
        //  string json = JsonUtility.ToJson(col);
        //     System.IO.File.WriteAllText(Application.persistentDataPath + "/data.json", json);

        setItems("dataStats",col);
       // col = getItems("dataStats");
        //Debug.Log(col);*/
    }
    /// <summary>
    /// save equipment stats 
    /// </summary>
    /// <param name="fileName">file name </param>
    /// <param name="colToSerilize">the list of items </param>
    public void setItems(string fileName, ItemList colToSerilize)
    {
        string json = JsonUtility.ToJson(colToSerilize);
        System.IO.File.WriteAllText(PATH + "/" + fileName + ".json", json);
    }
    /// <summary>
    /// get item from jason
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static ItemList getItems(string fileName)
    {
        string json = System.IO.File.ReadAllText(PATH +"/" +fileName+".json") ;
        return JsonUtility.FromJson<ItemList>(json);
    }
}
