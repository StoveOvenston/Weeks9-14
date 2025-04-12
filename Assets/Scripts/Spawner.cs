using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    //Creating public game objects for each prefab
    public GameObject SaberNeutral;
    public GameObject SaberUp;
    public GameObject SaberDown;
    public GameObject EnemySaberDown;
    public GameObject EnemySaberUp;
    public GameObject EnemySaberNeutral;
    //Creating Object with scripts attached
    public GameObject Combat;
    //Creating references to other scripts
    Combat combatScript;
    //CReating  game objects for instantiated objects making them public so that they be referenced elsewhere
    public GameObject saberneutral;
   public  GameObject saberup;
     public GameObject saberdown;
    //Same for enemies
    public GameObject enemysaberdown;
     public GameObject enemysaberup;
    public  GameObject enemysaberneutral;
    int enemySpawn;
    //Creating a boolean for each stance (enemy and player)
    //Player saber neutral is initially set to true as that is the stance the player sprite holds upon starting the game
    public Boolean playerSaberNeutral = true;
    //The other stances are set to false until instantiated
   public Boolean playerSaberUp = false;
    public Boolean playerSaberDown = false;
    //Enemy stances are all set to false until they are spawned
    public Boolean enemySaberNeutral = false;
    public Boolean enemySaberDown = false;
    public Boolean enemySaberUp = false; 
    // Start is called before the first frame update
   public void Start()
    {
        saberneutral = Instantiate(SaberNeutral);
        //Get component from combat object to get access to combat script
        combatScript = Combat.GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        //Each one of these if statements makes it so that when the saber stance changes, it destroys the previous stance
        if (playerSaberNeutral == false)
        {
            Destroy(saberneutral);
        }
        if (playerSaberUp == false)
        {
            Destroy(saberup);
        }
        if (playerSaberDown == false)
        {
            Destroy(saberdown);
        }
        playerStances();
        EnemySpawn();
    }
   //Function to set player stances
    void playerStances()
    {
        //If statements detect if a key is pressed and makes sure that each respective stance hasn't been spawned yet. 
        if (Input.GetKeyDown(KeyCode.D) && saberneutral == null ) {
           //These booleans make it so that once the stance changes, it sets the others to false, thus allowing for the if statements in update to destroy the other stance
            playerSaberNeutral = true;
            playerSaberUp = false;
             playerSaberDown = false;
            //Calls gameobject to instantiate prefab
            saberneutral = Instantiate(SaberNeutral);
        }
        if (Input.GetKeyDown(KeyCode.W) && saberup == null)
        {
            playerSaberNeutral = false;
            playerSaberUp = true;
            playerSaberDown = false;
            saberup = Instantiate(SaberUp);
           
        }
        if (Input.GetKeyDown(KeyCode.S) && saberdown == null) {
            playerSaberNeutral = false;
            playerSaberUp = false;
            playerSaberDown = true;
            saberdown = Instantiate(SaberDown);
        }
    }
    //Function for enemy spawning
    void EnemySpawn()
    {
        //Makes sure only 1 enemy spawns at a time by checking if any others have been spawned already
       if (enemysaberneutral == null && enemysaberup == null && enemysaberdown == null)
       {
          //Checks a random number between 1-4 and spawns the associated stance
            enemySpawn = UnityEngine.Random.Range(1, 4);
            if (enemySpawn == 1 && enemysaberneutral == null)
            {
                enemySaberNeutral = true;
                enemySaberDown = false;
                enemySaberUp = false;
                enemysaberneutral = Instantiate(EnemySaberNeutral);
                //Adds listener for the unity event so that this instantiated object can be yoinked and used within the combat script. Specifically the EnemyCombat(); Function
                EnemyController enemyController = enemysaberneutral.GetComponent<EnemyController>();
                enemyController.OnCombo.AddListener(combatScript.EnemyCombat);
            }
            if (enemySpawn == 2 && enemysaberup == null)
            {
                enemySaberNeutral = false;
                enemySaberDown = false;
                enemySaberUp = true;
                enemysaberup = Instantiate(EnemySaberUp);
                //Adds listener for the unity event so that this instantiated object can be yoinked and used within the combat script. Specifically the EnemyCombat(); Function
                EnemyController enemyController = enemysaberup.GetComponent<EnemyController>();
                enemyController.OnCombo.AddListener(combatScript.EnemyCombat);
            }
            if (enemySpawn == 3 && enemysaberdown == null)
            {
                enemySaberNeutral = false;
                enemySaberDown = true;
                enemySaberUp = false;
                enemysaberdown = Instantiate(EnemySaberDown);
                //Adds listener for the unity event so that this instantiated object can be yoinked and used within the combat script. Specifically the EnemyCombat(); Function
                EnemyController enemyController = enemysaberdown.GetComponent<EnemyController>();
                enemyController.OnCombo.AddListener(combatScript.EnemyCombat);
            }
       }
    }
    }

