using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
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

    public player_Weapons playerW;

    System.Random rng = new System.Random();

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
        enemyUnit.setName("Goblin Patrol");
        enemyUnit.setHealth(175);
        enemyUnit.setWeapon(0, 20, "Attack 1");
        enemyUnit.setWeapon(0, 15, "Attack 2");

        //Test display here

        //Set Hud player and enemy stats

        yield return new WaitForSeconds(2f);

        currentState = Battle_State.PlayerTurn;
        playerTurn();

    }

    IEnumerator attackEnemy(int weaponSlot)
    {

        yield return new WaitForSeconds(2f);

        enemyUnit.takeDmg(playerW.getWeapon(weaponSlot).getDamage());

        yield return new WaitForSeconds(2f);

        currentState = Battle_State.EnemyTurn;
        StartCoroutine(enemyTurn());

    }

    IEnumerator enemyTurn()
    {

        yield return new WaitForSeconds(3f);

        int attackSlot = rng.Next(1, 2);

        playerUnit.takeDmg(enemyUnit.getWeapons(attackSlot).getDamage());

        if (playerUnit.getHealth() <= 0)
        {

            currentState = Battle_State.Lost;
            endGame();

        }

        currentState = Battle_State.PlayerTurn;
        playerTurn();

    }

    void playerTurn()
    {

        //Let player know it is their turn
        Debug.Log("Your Turn.");

    }

    public void onAttackButton1()
    {

        if (currentState == Battle_State.PlayerTurn)
        {

            StartCoroutine(attackEnemy(1));

        }
    }

    public void onAttackButton2()
    {

        if (currentState == Battle_State.PlayerTurn)
        {

            StartCoroutine(attackEnemy(2));

        }
    }

    public void endGame()
    {

        if (currentState == Battle_State.Win)
        {

            Debug.Log("Won");
            //Pick new weapon
            //Load next scene
            //Maybe text

        }
        else
        {

            //restart battle
            Debug.Log("Lost");
        }
    }

}
