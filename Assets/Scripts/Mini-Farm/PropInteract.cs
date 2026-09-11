using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Resources;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class PropInteract : MonoBehaviour
{
    public GameObject RES_MANAGER = null; // Reference resource manager
    public GameObject RES_INDICATOR = null; // Indicator to show harvest readiness
    public int RES_TYPE = 0; // Resource type index (e.g., 0 for Milk, 1 for Eggs, 2 for Wheat)
    public bool HARWEST_READY = true;
    public bool RELOADING = false;

    // Resource table as a dictionary
    private static readonly Dictionary<int, ResourceData> ResourceTable = new Dictionary<int, ResourceData>
    {
        { 0, new ResourceData("Milk", 12, 10, 5) },   // Milk: Yield=12, Cost=10, Time=5s
        { 1, new ResourceData("Eggs", 10, 15, 4) },   // Eggs: Yield=10, Cost=15, Time=4s
        { 2, new ResourceData("Wheat", 20, 25, 6) }  // Wheat: Yield=20, Cost=25, Time=6s
    };

    private ResourceData resourceData;

    void Start()
    {
        // Load resource data based on RES_TYPE
        if (ResourceTable.ContainsKey(RES_TYPE))
        {
            resourceData = ResourceTable[RES_TYPE];
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Interact()
    {
        if (HARWEST_READY) { Harwest(); }
        else if (!RELOADING) { Reload(); }
    }
    void Harwest()
    {
        if (HARWEST_READY)
        {
            RES_INDICATOR.SetActive(false);
            RES_MANAGER.GetComponent<ResourceManager>().AddResource(RES_TYPE, resourceData.Yield); ;
            HARWEST_READY = false;
        }
    }
    void Reload()
    {
        if ((!HARWEST_READY) && (RES_MANAGER.GetComponent<ResourceManager>().GetResource(3) >= resourceData.Cost) && (!RELOADING))
        {
            
            RES_MANAGER.GetComponent<ResourceManager>().SpendResource(3, resourceData.Cost);
            RELOADING = true;
            GameObject Test = gameObject.transform.Find("Canvas(Timer)").gameObject;
            Test.SetActive(true);
            gameObject.transform.GetComponent<TimerFill>().RestartTimer(resourceData.ReloadTime, resourceData.ReloadTime);
            StartCoroutine(Load(Test));

        }
    }
    IEnumerator Load(GameObject Test)
    {
        yield return new WaitForSeconds(resourceData.ReloadTime);
        Test.SetActive(false);
        RELOADING = false;
        RES_INDICATOR.SetActive(true);
        HARWEST_READY = true;
    }
    private class ResourceData
    {
        public string Name { get; }
        public int Yield { get; }
        public int Cost { get; }
        public float ReloadTime { get; }

        public ResourceData(string name, int yield, int cost, float reloadTime)
        {
            Name = name;
            Yield = yield;
            Cost = cost;
            ReloadTime = reloadTime;
        }
    }
}
