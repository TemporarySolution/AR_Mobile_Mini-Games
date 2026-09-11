using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class ResourceManager : MonoBehaviour
{
    public int Coins = 100; // Initial coins
    public GameObject CoinsUI = null;// Gold
    public GameObject MilkUI = null;// Milk 
    public GameObject EggsUI = null;// Eggs
    public GameObject WheatUI = null;// Wheat

    private Dictionary<int, int> resources = new Dictionary<int, int>
    {
        { 0, 100 }, // Milk
        { 1, 100 }, // Eggs
        { 2, 100 }, // Wheat
        { 3, 350 } // Gold
    };
    private Dictionary<int, GameObject> resourceUI;

    void Start()
    {
        // Initialize the resource UI dictionary
        resourceUI = new Dictionary<int, GameObject>
        {
            { 0, MilkUI },
            { 1, EggsUI },
            { 2, WheatUI },
            { 3, CoinsUI },

        };

        UpdateUI();
    }

    public void AddResource(int resType, int amount)
    {
        if (resources.ContainsKey(resType))
        {
            resources[resType] += amount;
           UnityEngine.Debug.Log($"Added {amount} of resource type {resType}. Total: {resources[resType]}");
            UpdateUI();
        }
        else
        {
            UnityEngine.Debug.LogError("Invalid resource type!");
        }
    }

    public void SpendResource(int resType, int amount)
    {
        if (resources[resType] >= amount)
        {
            resources[resType] -= amount;
           UnityEngine.Debug.Log($"Spent {amount} of {resType}. Remaining: {resources[resType]}");
            UpdateUI();
        }
        else
        {
            UnityEngine.Debug.LogError($"Not enough {resType}!");
        }
    }

    public int GetResource(int resType)
    {
        return resources.ContainsKey(resType) ? resources[resType] : 0;
    }
    // Updates the UI elements
    void UpdateUI()
    {
        foreach (var entry in resourceUI)
        {
            int resType = entry.Key;
            GameObject resourceObject = entry.Value;

            if (resourceObject != null)
            {
                resourceObject.transform.Find("Count/Text").GetComponent<UnityEngine.UI.Text>().text = $"{resources[resType]}"; ;
            }
        }
    }
    public void TradeResource()
    {
        if  ((resources[0] >= 35) && (resources[1] >= 60) && (resources[2] >= 70))
        {
            SpendResource(0, 35);
            SpendResource(1, 60);
            SpendResource(2, 70);
            AddResource(3, 550);
        }
        else
        {
            UnityEngine.Debug.LogError($"Not enough resources! You need {35 - resources[0]}");
        }

    }
}

