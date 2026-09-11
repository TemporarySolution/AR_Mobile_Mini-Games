using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int TEAM_TURN = 0;
    public int [] TEAMS = { 1, 2 };
    public int MAX_ACTIONS = 2;
    public int CURRENT_ACTIONS = 2;
    public int TURN = 1;

    public GameObject GUi = null;

    // Start is called before the first frame update
    void Start()
    {
        TEAM_TURN = 1;
        UpdGUi();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    private Dictionary<int, int> resources = new Dictionary<int, int>
    {
        { 0, 100 }, // Milk
        { 1, 100 }, // Eggs
        { 2, 100 }, // Wheat
        { 3, 350 } // Gold
    };

    public void EndTurn()
    {
        TURN++;
        print("TURN % TEAMS.Length =        " + (TURN % TEAMS.Length));
        print("TEAMS.Length - TURN % TEAMS.Length =         " + (TEAMS.Length - TURN % TEAMS.Length));
        TEAM_TURN = TEAMS[(TEAMS.Length - TURN % TEAMS.Length)-1];
        
        
        
        CURRENT_ACTIONS = MAX_ACTIONS;
        UpdGUi();
    }
    public void UpdGUi()
    {
        GUi.transform.Find("ActionCount/Text(TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = "Очки действий: " + CURRENT_ACTIONS + "/" + MAX_ACTIONS; ;
        GUi.transform.Find("RoundCount/Text(TMP)").GetComponent<TextMeshProUGUI>().text = "Раунд :" + TURN; ;
        GUi.transform.Find("WhosTurn/Text(TMP)").GetComponent<TextMeshProUGUI>().text = "Ход:" + (TEAM_TURN == 1 ? "Синий" : "Красный"); ;
    }
    public void Action()
    {
        CURRENT_ACTIONS--;
        UpdGUi();
        if (CURRENT_ACTIONS == 0) { EndTurn(); }
    }
}
