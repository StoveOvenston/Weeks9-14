using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Combat : MonoBehaviour
{
    //Visual combat objects
    public GameObject HitOne;
        public GameObject HitTwo;
        public GameObject HitThree;
    public GameObject Die;
 
    //Private versions
    GameObject hitone;
    GameObject hittwo;
    GameObject hitthree;
    
    //Call Gameobjects to reference with get
    public GameObject StanceSpawner;
   // Call scripts to use for get component 
    Spawner spawnscript;
    EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the spawner script so that I can reference it's variables 
        spawnscript = StanceSpawner.GetComponent<Spawner>();
    

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void EnemyCombat()
    {
        //Checks if the player stance matches the enemy stance. Destroys the enemy  and prints (enemy hit)
        if(spawnscript.playerSaberUp == true  && spawnscript.enemySaberUp == true )
        {
            //Destroys enemy
            Destroy(spawnscript.enemysaberup);
            Debug.Log("Enemy hit");
            //Instantiate background
            hitone = Instantiate(HitOne);
            //Destroys previous background
            Destroy(hittwo);
            Destroy(hitthree);
            
        }
        //Checks if the player stance matches the enemy stance. Destroys the enemy  and prints (enemy hit)
        else if (spawnscript.playerSaberDown == true && spawnscript.enemySaberDown == true)
        {
            Destroy(spawnscript.enemysaberdown);
            Debug.Log("Enemy hit");
            hittwo = Instantiate(HitTwo);
            Destroy(hitone);
            Destroy(hitthree);
            
        }
        //Checks if the player stance matches the enemy stance. Destroys the enemy  and prints (enemy hit)
        else if (spawnscript.playerSaberNeutral == true && spawnscript.enemySaberNeutral == true)
        {
            Destroy(spawnscript.enemysaberneutral);
            Debug.Log("Enemy hit");
            hitthree = Instantiate(HitThree);
            Destroy(hittwo);
            Destroy(hitone);
          
        }
        //If the player's stance does not match then it will kill the player and reset the enemy prints in the log instructions to respawn
        else  {
            Destroy(spawnscript.saberdown);
            Destroy(spawnscript.saberneutral);
            Destroy(spawnscript.saberup);
            Destroy(spawnscript.enemysaberup);
            Destroy(spawnscript.enemysaberdown);
            Destroy(spawnscript.enemysaberneutral);
          
            //Destroy active screens
            Destroy(hittwo);
            Destroy(hitone);
            Destroy(hitthree);
            
            Debug.Log("Press button to respawn");

        }
    }
}
