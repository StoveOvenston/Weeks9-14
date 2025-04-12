using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Combat : MonoBehaviour
{
    
    //Call Gameobjects to reference with get
    public GameObject StanceSpawner;
    public GameObject EnemySaberDown;
    public GameObject EnemySaberUp;
    public GameObject EnemySaberNeutral;
    Spawner spawnscript;
    EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        spawnscript = StanceSpawner.GetComponent<Spawner>();
       
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void EnemyCombat()
    {
        if(spawnscript.playerSaberUp == true  && spawnscript.enemySaberUp == true )
        {

            Destroy(spawnscript.enemysaberup);
            Debug.Log("Enemy hit");
        }
        else if (spawnscript.playerSaberDown == true && spawnscript.enemySaberDown == true)
        {
            Destroy(spawnscript.enemysaberdown);
            Debug.Log("Enemy hit");
        }
        else if (spawnscript.playerSaberNeutral == true && spawnscript.enemySaberNeutral == true)
        {
            Destroy(spawnscript.enemysaberneutral);
            Debug.Log("Enemy hit");
        }
        else  {
            Destroy(spawnscript.saberdown);
            Destroy(spawnscript.saberneutral);
            Destroy(spawnscript.saberup);
            Destroy(spawnscript.enemysaberup);
            Destroy(spawnscript.enemysaberdown);
            Destroy(spawnscript.enemysaberneutral);


        }
    }
}
