using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;

    public float moveSpeed;

    private CharacterController controller;
   
    void Start() 
    {
        playerAnim = GetComponent<Animator>(); 
        controller = GetComponent<CharacterController>();
       
    }

   IEnumerator SetState(bool state){
       playerAnim.SetBool("running", state);
       yield return null;
   }
    
    void Update()
    {
         float walkInput = Input.GetAxis("Horizontal"); // get left-right buttons
         float frontInput = Input.GetAxis("Vertical");
         IEnumerator coroutine;

         if(walkInput != 0f  || frontInput != 0f){
             coroutine = SetState(true);
             StartCoroutine(coroutine);
         }

          Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
          
          
          if(walkInput > 0f){
              print("right");
              transform.rotation = Quaternion.Euler(0f, walkInput * 90f, 0f); // rotate Right 
          }
          else if(walkInput < 0f){
              print("left");
              transform.rotation = Quaternion.Euler(0f, walkInput * 90f, 0f); // rotate Left
          }
          if (move != Vector3.zero)
            {
                
               //transform.forward = move;
               coroutine = SetState(true);
               StartCoroutine(coroutine);
               
               controller.Move(move * Time.deltaTime * moveSpeed);
                
            } else {
                print("Staying still");
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
               
                coroutine = SetState(false);
                StartCoroutine(coroutine);
            }

    }
}
