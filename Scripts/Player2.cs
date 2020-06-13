using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour{

    float speed = 1;
    float rotSpeed = 80;
    float gravity = 8;
    float rot = 0f;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;

    Animator anim;

    void Start(){
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update(){
        if(controller.isGrounded){
            if(Input.GetKey(KeyCode.W)){

                anim.SetBool("running", true);
                moveDir = new Vector3(0,0,1);
                moveDir *=speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            if(Input.GetKeyUp(KeyCode.W)){
                anim.SetBool("running", false);
                moveDir = new Vector3(0,0,0);
            }
        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -=gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
}