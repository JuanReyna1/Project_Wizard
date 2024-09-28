using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Battle_State { Start, PlayerTurn, EnemyTurn, Win, Lost }

public class Turn_Based_Logic : MonoBehaviour
{

    public Battle_State currentState;

    public GameObject playerPreFab;
    public GameObject[] enemiesPreFab;
    public GameObject enemyPreFab;

    public Transform playerPos;
    public Transform enemyPos;
    private Unit_Class playerUnit;
    private Unit_Class enemyUnit;

    private void Start()
    {

        currentState = Battle_State.Start;
        StartCoroutine(startBattle());

    }

    IEnumerator startBattle()
    {

        GameObject player = Instantiate(playerPreFab, playerPos);
        playerUnit = player.GetComponent<Unit_Class>();
        playerUnit.setName("Wizard");
        playerUnit.setHealth(100);

        GameObject enemyGO = Instantiate(enemyPreFab, enemyPos);
        enemyUnit = enemyGO.GetComponent<Unit_Class>();
        playerUnit.setName("Goblin Patrol");
        playerUnit.setHealth(175);

        //Test display here

        //Set Hud player and enemy stats

        yield return new WaitForSeconds(2f);

        currentState = Battle_State.PlayerTurn;
        playerTurn();

    }

    IEnumerator attackEnemy()
    {


    }

    void playerTurn()
    {

        //Let player know it is their turn

    }

    public void onAttackButton()
    {

        if (currentState == Battle_State.PlayerTurn)
        {

            StartCoroutine(attackEnemy());

        }
    }

}
