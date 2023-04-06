using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timer=0;
    public float damage = 1;
    // Vector3 my_position;
    //Rigidbody2D my_rigid;
    // Start is called before the first frame update
    void Start()
    {
        //my_rigid = GetComponent<Rigidbody2D>();
        //my_position = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //my_position = my_position + new Vector3(0, 1f, 0)*Time.deltaTime;

        //gameObject.transform.position = my_position;

        timer = timer + Time.deltaTime;

        if (timer > 3)
        {
            Destroy(gameObject);
        }
        

        
    }

}
