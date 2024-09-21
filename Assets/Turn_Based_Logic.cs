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

    private void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex == 12)
        {

            enemyPreFab = enemiesPreFab[Random.Range(0, enemiesPreFab.Length)];

        }
        else
        {

            //Offset is 2
            enemyPreFab = enemiesPreFab[SceneManager.GetActiveScene().buildIndex - 2];

        }

        currentState = Battle_State.Start;
        startBattle();

    }

    public void startBattle()
    {

        GameObject player = Instantiate(playerPreFab, playerPos);


        GameObject enemyGO = Instantiate(enemyPreFab, enemyPos);

    }

}
