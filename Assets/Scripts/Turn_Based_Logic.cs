using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Battle_State { Start, PlayerTurn, EnemyTurn, Win, Lost }

public class Turn_Based_Logic : MonoBehaviour
{

    public Battle_State currentState;

    [Header ("Prefabs & Scripts")]
    public GameObject playerPreFab;
    public GameObject[] enemiesPreFab;
    public GameObject enemyPreFab;
    public Transform playerPos;
    public Transform enemyPos;
    public player_Weapons playerW;

    [Header ("Hud")]
    public Canvas playerHUD;
    public Slider playerHealth;
    public Slider enemyHealth;
    public GameObject txtDisplay;
    private GameObject bckGround;
    private TMP_Text display;
    public Button att1;
    public Button att2;
    public Button block;
    public Button spAtt;
    public GameObject sysEv;

    private Unit_Class playerUnit;
    private Unit_Class enemyUnit;

    readonly System.Random rng = new System.Random();

    void Start()
    {

        bckGround = txtDisplay.transform.parent.gameObject;
        display = txtDisplay.GetComponent<TMP_Text>();
        currentState = Battle_State.Start;
        StartCoroutine(startBattle());

    }

    IEnumerator startBattle()
    {

        GameObject player = Instantiate(playerPreFab, playerPos);
        playerUnit = player.GetComponent<Unit_Class>();
        playerUnit.setName("Wizard");
        playerUnit.setHealth(100);
        playerW.setWeapon(0, 10, "Warlock Punch");
        playerW.setWeapon(1, 15, "Spiked Wand");

        GameObject enemyGO = Instantiate(enemyPreFab, enemyPos);
        enemyUnit = enemyGO.GetComponent<Unit_Class>();
        enemyUnit.setName("Goblin Patrol");
        enemyUnit.setHealth(175);
        enemyUnit.setWeapon(0, 20, "Attack 1");
        enemyUnit.setWeapon(0, 15, "Attack 2");

        //Test display here
        bckGround.SetActive(true);
        display.text = "Starting battle...";

        //Set Hud player and enemy stats
        playerHealth.maxValue = playerUnit.getHealth();
        playerHealth.value = playerUnit.getHealth();

        enemyHealth.maxValue = enemyUnit.getHealth();
        enemyHealth.value = enemyUnit.getHealth();

        yield return new WaitForSeconds(2f);

        //display
        display.text = "Begins in 3 seconds!";

        yield return new WaitForSeconds(3f);

        //Display
        bckGround.SetActive(false);
        display.text = "";

        currentState = Battle_State.PlayerTurn;
        playerTurn();

    }

    IEnumerator attackEnemy(int weaponSlot)
    {

        yield return new WaitForSeconds(2f);

        enemyUnit.takeDmg(playerW.getWeapon(weaponSlot).getDamage());
        enemyHealth.value = enemyUnit.getHealth();

        yield return new WaitForSeconds(2f);

        currentState = Battle_State.EnemyTurn;
        StartCoroutine(enemyTurn());

    }

    IEnumerator enemyTurn()
    {

        //currentState = Battle_State.EnemyTurn;

        //Display
        bckGround.SetActive(true);
        display.text = "Enemy Turn";

        yield return new WaitForSeconds(3f);

        int attackSlot = rng.Next(0, 1);

        playerUnit.takeDmg(enemyUnit.getWeapons(attackSlot).getDamage());
        playerHealth.value = playerUnit.getHealth();

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
        
        //Display
        bckGround.SetActive(true);
        display.text = "Player Turn";

        sysEv.SetActive(true);

    }

    public void onAction(int attack)
    {

        sysEv.SetActive(false);

        if (currentState == Battle_State.PlayerTurn)
        {

            bckGround.SetActive(false);
            display.text = "";

            if (attack <= 1)
            {

                StartCoroutine(attackEnemy(attack));

            }

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
