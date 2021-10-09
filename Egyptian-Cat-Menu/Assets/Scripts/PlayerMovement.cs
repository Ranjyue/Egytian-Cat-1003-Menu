using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;
    Animator anim;
    public GameObject myBag;
    bool isOpen;
    public float speed;
    Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();
        SwitchAnim();
        OpenMyBag();
    }

    void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

    }

    void SwitchAnim()
    {
        if (movement != Vector2.zero)
        {
            anim.SetFloat("horizontal", movement.x);
            anim.SetFloat("vertical", movement.y);
        }
        anim.SetFloat("speed", movement.magnitude);
    }

    void OpenMyBag() // 打開背包
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }

}