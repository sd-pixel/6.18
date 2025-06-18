using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveForce;

    Vector2 moveDir;
    Rigidbody2D rb;

    Transform childObj;

    float fishScale = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        childObj = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        float h= Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        moveDir = new Vector2(h, v).normalized;


        if (h > 0)
       
            childObj.localScale=new Vector3(1, 1, 1);
        else if (h < 0)
            childObj.localScale = new Vector3(-1, 1, 1);
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDir*moveForce);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Finsh>() != null)
        {
            if (fishScale > collision.gameObject.GetComponent<Finsh>().fishScale)
            {
                Destroy(collision.gameObject);
                Grow(collision.gameObject.GetComponent<Finsh>().fishScale);
            }
            else
            {
                Die();
            }
        }
    }

    private void Die()
    {
       Debug.Log("You died");

       FindObjectOfType<GameManger>().GameOver();
    }

    void Grow(float value)
    {
        fishScale += value / 20f;
        transform.localScale = Vector3.one * fishScale;


        FindObjectOfType<GameManger>().GainScore((int)(value*100));
        
    }
}
