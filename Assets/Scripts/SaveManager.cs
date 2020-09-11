using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

[Serializable]
public class SaveManager : MonoBehaviour
{

    public Click click;
    public UpgradeManager[] Upgrades;
    public ItemManager[] Items;
    public List<Upgrade> UpgradesList;
    public List<Item> ItemsList;

    private int counter = 0;

    void Awake()
    { 
        Load();
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "playerInfo.slv");
        GameData data = new GameData();
        data.GoldData = click.gold;
        data.GoldPerClickData = click.goldperclick;
        UpgradesList = new List<Upgrade>();
        foreach (UpgradeManager upgrade in Upgrades)
        {
            UpgradesList.Add(new Upgrade(Upgrades[counter].count, Upgrades[counter].clickPower, Upgrades[counter].cost));
            counter++;
        }
        counter = 0;
        data.UpgradesData = UpgradesList;
        foreach (ItemManager item in Items)
        {
            ItemsList.Add(new Item(Items[counter].count, Items[counter].cost));
            counter++;
        }
        counter = 0;
        data.ItemsData = ItemsList;
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "playerInfo.slv"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "playerInfo.slv", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);         
            click.gold = data.GoldData;
            click.goldperclick = data.GoldPerClickData;
            foreach (Upgrade upgrade in data.UpgradesData)
            {
                Upgrades[counter].count = upgrade.UpgradeCount;
                Upgrades[counter].clickPower = upgrade.UpgradeClickPower;
                Upgrades[counter].cost = upgrade.UpgradeCost;
                counter++;
            }
            counter = 0;
            foreach (Item item in data.ItemsData)
            {
                Items[counter].count = item.ItemCount;
                Items[counter].cost = item.ItemCost;
                counter++;
            }
            counter = 0;
            file.Close();
        }
        else
        {
            FileStream file = File.Create(Application.persistentDataPath + "playerInfo.slv");
            Save();
        }
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
            Save();
        else
            Load();
    }
}


[Serializable]
class GameData
{
    public float GoldData;
    public int GoldPerClickData;
    public List<Upgrade> UpgradesData;
    public List<Item> ItemsData;
}

[Serializable]
public class Upgrade
{
    public int UpgradeCount;
    public int UpgradeClickPower;
    public float UpgradeCost;
    private int count;

    public Upgrade(int count, int clickPower, float cost)
    {
        UpgradeCount = count;
        UpgradeClickPower = clickPower;
        UpgradeCost = cost;
    }
}

[Serializable]
public class Item
{
    public int ItemCount;
    public float ItemCost;
    private int count;

    public Item(int count, float cost)
    {
        this.ItemCount = count;
        ItemCost = cost;
    }
}
