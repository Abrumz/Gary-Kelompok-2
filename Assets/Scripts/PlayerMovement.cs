using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;

    public float runSpeed;
    float score;

    public Text ScoreText;

    float horizontalMove = 0f;
    
    [SerializeField]
    bool jump = false;
    bool crouch = false;
    bool isGrounded = false;
    bool isAlive = true;

    Rigidbody2D RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (isAlive)
        {
            score += Time.deltaTime * 5;
            ScoreText.text = "SCORE : " + score.ToString("F");
        }
    }

    void FixedUpdate()
    {
        // Move Our Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("Obstacles"))
        {
            isAlive = false;
            Time.timeScale = 0;
        }
    }
}
