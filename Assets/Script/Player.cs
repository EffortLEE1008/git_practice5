using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D my_rigid;
    float speed=100f;

    // Start is called before the first frame update

    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 next_pos = new Vector3(h, v, 0);
        next_pos = next_pos.normalized;


        my_rigid.MovePosition(transform.position + next_pos * speed * Time.deltaTime);
        
    }
}
