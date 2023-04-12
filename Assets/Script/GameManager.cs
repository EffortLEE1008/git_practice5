using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemy;

    [SerializeField]
    Transform[] spawn_postition;
    [SerializeField]
    Transform playerspawnPos;
        

    float max_timer=.7f;
    float cur_timer;
    int randomnum;


    [SerializeField]
    GameObject player;

    
    public Text scoreText;
    public Image[] lifeImage;
    public GameObject gameoverObj;

    private void Awake()
    {
        Instantiate(player, playerspawnPos.position, playerspawnPos.rotation);
        Player playerlogic = player.GetComponent<Player>();
        playerlogic.score = 0;

    }

    private void Update()
    {
        cur_timer = cur_timer + Time.deltaTime;


        if (cur_timer >= max_timer)
        {
            randomnum = Random.Range(0, 5);
            //randomnum = (int)Mathf.Floor(randomnum);
            //Instantiate(enemy[0], new Vector2(-2, 3.6f), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(enemy[0], spawn_postition[randomnum].position, spawn_postition[randomnum].rotation);

     
            
            cur_timer = 0;
        }

        Player playerlogic = player.GetComponent<Player>();
        scoreText.text = string.Format("{0:n0}", playerlogic.score);
            

    }
    public void ReSpawnPlayer()
    {
        Invoke("Spawnplayer", 1f);

    }
    public void LifeImageUpdate(int life)
    {

        for (int i = 0; i < 3; i++)
        {
            lifeImage[i].color = new Color(1, 1, 1, 0);
        }

        for (int i=0; i<life; i++)
        {
            lifeImage[i].color = new Color(1, 1, 1, 1);
        }

    }
    public void ActiveGameover()
    {
        gameoverObj.SetActive(true);
    }

    void Spawnplayer()
    {
        
        player.transform.position = playerspawnPos.position;
        player.SetActive(true);
        
    }
    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }



}
