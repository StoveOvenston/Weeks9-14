using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Coroutine enemyMovement;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enemymovement());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator Enemymovement()
    {
        float speed = 1f;
        while (true)
        {
            Vector3 enemyPosition = transform.position;
            enemyPosition.x -= speed;
            transform.position = enemyPosition;
            if (enemyPosition.x == -5f)
            {
                yield return new WaitForSeconds(6f);
            }
        }
    }
}
