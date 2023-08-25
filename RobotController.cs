using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    Rigidbody2D robotRd;
    public float walkSpeed = 15.0f;
    Animator animator;
    float maxSpeed = 3.0f;
    float jumpSpeed = 20.0f;
    AudioSource audioSource;


    void Start()
    {
        robotRd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        AudioSource CoinSound = GetComponent<AudioSource>();
        AudioSource BombSound = GetComponent<AudioSource>();
        animator.speed = 0f;
        
    }


    void Update() {
        float speedx = Mathf.Abs(robotRd.velocity.x);

        if(Input.GetKey(KeyCode.Space) && (transform.position.y <= 3.7f )) {
            animator.SetTrigger("JumpCile");
            robotRd.AddForce(transform.up * jumpSpeed);
            
            if(Input.GetKey(KeyCode.LeftArrow) == true) {
                robotRd.AddForce( transform.right * -1 * walkSpeed);
                transform.localScale = new Vector3(-1.0f, 1.0f, 1); }
            if(Input.GetKey(KeyCode.RightArrow) == true) {
                robotRd.AddForce( transform.right * walkSpeed);
                transform.localScale = new Vector3(1.0f, 1.0f, 1);}                                    
           


            
        }

        if(speedx < maxSpeed) 
        {
        if(Input.GetKey(KeyCode.LeftArrow) == true) {
            robotRd.AddForce( transform.right * -1 * walkSpeed);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1);
                                                    }
        if(Input.GetKey(KeyCode.RightArrow) == true){
            robotRd.AddForce( transform.right * walkSpeed);
            transform.localScale = new Vector3(1.0f, 1.0f, 1);
                                                    }
        }
         animator.speed = speedx;
        }
        void OnCollisionEnter2D(Collision2D other) {
            if(other.collider.tag == "Coin") {
            AudioSource CoinSound = GetComponent<AudioSource>();
            CoinSound.Play();
        }

        void OnCollisionEnter2D(Collision2D other) {
            if(other.collider.tag == "Bomb") {
            AudioSource BombSound = GetComponent<AudioSource>();
            BombSound.Play();
            }
        }
        }
}