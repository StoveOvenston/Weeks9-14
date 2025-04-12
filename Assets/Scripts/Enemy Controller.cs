using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{

    //Event
    public UnityEvent OnCombo;
    //public UnityEvent OnDownwardCombo;
   // public UnityEvent OnNeutralCombo;
    //Coroutine for enemymovement
    Coroutine enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
     //Starts the coroutine so that the enemy can begin moving.
        StartCoroutine(Enemymovement());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    //Create Coroutine
    IEnumerator Enemymovement()
    {
        //Float for the speed of the enemy
        float speed = .01f;
       //Boolean value that checks if the enemy has done it's pause. If it hasn't then it can pause and if it has then it cant pause again
        bool hasPaused = false;
       //A while loop so that the movement can be constant frame by frame.
        while (true)
        {
            //VEctor 3 for enemy movement
            Vector3 enemyPosition = transform.position;
            enemyPosition.x -= speed;
            transform.position = enemyPosition;
           //Checks the position of the enemy and if it has paused. If it hasn't paused yet then the enemy stops for 2 seconds before moving again
            if (enemyPosition.x <= -7f && hasPaused == false)
            {
                Debug.Log("Enemy has paused. Invoking combo event.");
                yield return new WaitForSeconds(2f);
                hasPaused = true;
                // INvokes unity event when enemy is paused reading for the stances
                
                OnCombo.Invoke();
               // OnDownwardCombo.Invoke();
                //OnNeutralCombo.Invoke();

            }
         
                //Yield that prevents unity from CRASHING
                yield return null;
        }
       
    }
}
