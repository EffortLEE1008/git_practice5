using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D my_rigid;
    float speed=100f;

    public bool hit_rightbox;
    public bool hit_leftbox;
    public bool hit_topbox;
    public bool hit_bottombox;

    // Start is called before the first frame update

    void Start()
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


        my_rigid.MovePosition(transform.position + next_pos * speed * Time.deltaTime);
        
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
