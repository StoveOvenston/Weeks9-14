using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Creating public game objects for each prefab
    public GameObject SaberNeutral;
    public GameObject SaberUp;
    public GameObject SaberDown;
    //CReating private game objects for instantiated objects
    GameObject saberneutral;
     GameObject saberup;
     GameObject saberdown;
    //Creating a boolean for each stance (enemy and player)
    //Player saber neutral is initially set to true as that is the stance the player sprite holds upon starting the game
    Boolean playerSaberNeutral = true;
    //The other stances are set to false until instantiated
    Boolean playerSaberUp = false;
    Boolean playerSaberDown = false;
    //Enemy stances are all set to false until they are spawned
    Boolean enemySaberNeutral = false;
    Boolean enemySaberDown = false;
    Boolean enemySaberUp = false; 
    // Start is called before the first frame update
    void Start()
    {
        saberneutral = Instantiate(SaberNeutral);
    }

    // Update is called once per frame
    void Update()
    {
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
    }
   //Function to set player stances
    void playerStances()
    {
        if (Input.GetKeyDown(KeyCode.D)) {
            playerSaberNeutral = true;
            playerSaberUp = false;
             playerSaberDown = false;
            saberneutral = Instantiate(SaberNeutral);
        }
        if (Input.GetKeyDown(KeyCode.W)) {
            playerSaberNeutral = false;
            playerSaberUp = true;
            playerSaberDown = false;
            saberup = Instantiate(SaberUp);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            playerSaberNeutral = false;
            playerSaberUp = false;
            playerSaberDown = true;
            saberdown = Instantiate(SaberDown);
        }
    }
}
