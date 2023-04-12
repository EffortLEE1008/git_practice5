using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D my_rigid;
    [SerializeField]
    float flyspeed=10f;

    [SerializeField]
    float fire_delay=0;

    public bool hit_rightbox;
    public bool hit_leftbox;
    public bool hit_topbox;
    public bool hit_bottombox;

    public int hp = 3;
    
    public float score;
    

    [SerializeField]
    GameObject bullet;

    public GameManager manager;

   

    // Start is called before the first frame update
    private void Awake()
    {
        
        my_rigid = GetComponent<Rigidbody2D>();
        
    }



    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((hit_rightbox && h == 1)||(hit_leftbox && h == -1))
            h = 0;

        float v = Input.GetAxisRaw("Vertical");
        if ((hit_topbox && v == 1) || (hit_bottombox && v == -1))
            v = 0;

        Vector3 next_pos = new Vector3(h, v, 0);
        next_pos = next_pos.normalized;


        my_rigid.MovePosition(transform.position + next_pos * flyspeed * Time.deltaTime);

        fire_delay = fire_delay + Time.deltaTime;
        if (fire_delay > .15f)
        {
            fire();
            fire_delay = 0;
            
           
        }
        //Debug.Log("Fire_delayÀÇ °ªÀº? : " + fire_delay);

        
    }
    void fire()
    {
        GameObject fire = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody2D rigid = fire.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 500);

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Boundary")
        {
            switch (collision.gameObject.name)
            {
                case "Right_box":
                    hit_rightbox = true;
                    break;

                case "Bottom_box":
                    hit_bottombox = true;
                    break;


                case "Left_box":
                    hit_leftbox = true;
                    break;

                case "Top_box":
                    hit_topbox = true;
                    break;

            }
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            hp--;
            manager.LifeImageUpdate(hp);

            if (hp == 0)
            {
                manager.ActiveGameover();

            }
            else
            {

                manager.ReSpawnPlayer();

            }

            gameObject.SetActive(false);
            Destroy(collision.gameObject);

        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Boundary")
        {
            switch (collision.gameObject.name)
            {
                case "Right_box":
                    hit_rightbox = false;
                    break;

                case "Bottom_box":
                    hit_bottombox = false;
                    break;

                case "Left_box":
                    hit_leftbox = false;
                    break;

                case "Top_box":
                    hit_topbox = false;
                    break;

            }
        }

    }

}
