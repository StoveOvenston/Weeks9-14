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
        enemyController = EnemySaberUp.GetComponent<EnemyController>();
        enemyController.OnUpwardCombo.AddListener(EnemyCombat);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void EnemyCombat()
    {
        if(spawnscript.playerSaberUp == true  && spawnscript.enemySaberDown == true )
        {
            Destroy(EnemySaberUp);
        }
    }
}
