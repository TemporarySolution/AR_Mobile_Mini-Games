using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public GameObject GameController = null;

    public GameObject SELECTED = null;
    public GameObject SELECTED_ENEMY = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TrySelect(GameObject TARGET)
    {
        if (SELECTED_ENEMY) { SELECTED_ENEMY.GetComponent<Unit>().SetDeselected(); SELECTED_ENEMY = null; }
        
        if (TARGET == null)
        {
            return;
        }
        if ((TARGET.GetComponent<Unit>().TEAM != GameController.GetComponent<GameController>().TEAM_TURN) && (SELECTED == null))
        {
            SELECTED_ENEMY = TARGET;
            SELECTED_ENEMY.GetComponent<Unit>().SetSelectedAsEnemy();
            print("Это не ваш Юнит!");
            return;
        }
        if (TARGET == SELECTED) { SELECTED.GetComponent<Unit>().SetDeselected(); SELECTED = null; }
        else if ((TARGET != SELECTED) && (SELECTED == null)) 
        { 
            SELECTED = TARGET; 
            SELECTED.GetComponent<Unit>().SetSelected(); 
        }
        else if ((TARGET != SELECTED) && (TARGET.GetComponent<Unit>().TEAM != SELECTED.GetComponent<Unit>().TEAM))
        {
            if (SELECTED.GetComponent<Unit>().TryAttack(TARGET)) { GameController.GetComponent<GameController>().Action(); }
            print("Юнит: " + SELECTED + "Атакует: " + TARGET);
            SELECTED.GetComponent<Unit>().SetDeselected();
            SELECTED = null;
            TARGET = null;
            
        }
        else if ((TARGET != SELECTED) && (TARGET.GetComponent<Unit>().TEAM == SELECTED.GetComponent<Unit>().TEAM))
        {
            SELECTED.GetComponent<Unit>().SetDeselected();
            SELECTED = TARGET;
            SELECTED.GetComponent<Unit>().SetSelected();
        }
    }
}
