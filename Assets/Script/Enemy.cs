using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D my_rigid;
    
    float as_speed = .6f;

    float health = 10;
    Bullet bullet;
    

    private void Awake()
    {
        my_rigid = GetComponent<Rigidbody2D>();
        my_rigid.velocity = Vector2.down * as_speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, .3f));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.transform.tag == "PlayerBullet")
        {
            bullet = collision.gameObject.GetComponent<Bullet>();
            hit(bullet.damage);
            Destroy(collision.gameObject);
        }

        
    }


    void hit(float damage)
    {
        health = health - damage;
        Debug.Log("운석이 데미지를 입었습니다 남은 체력 : " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
