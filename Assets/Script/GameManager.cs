using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemy;

    [SerializeField]
    Transform[] spawn_postition;

    float max_timer;
    float cur_timer;

    private void Update()
    {

        Instantiate(enemy[0], new Vector2(-2, 3.6f), Quaternion.Euler(new Vector3(0, 0, 0)));

    }

    void SpawnEnemy()
    {
        
    }



}
