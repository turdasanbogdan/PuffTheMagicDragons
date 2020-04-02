using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator playerAnim; // will be player Animator
    //Animator = the area where we can transit from walking to breathing
    // Start is called before the first frame update
    private Rigidbody rbody;
    private float moveSpeed;

    void Start()
    {
    	playerAnim = GetComponent<Animator>(); 
    	rbody = GetComponent<Rigidbody>(); 
    	moveSpeed = 500f;
        
    }

    // Update is called once per frame
    void Update()
    {
        float walkInput = Input.GetAxis("Horizontal"); // get left-right buttons

        //walk right
        if(walkInput > 0f ){
        	playerAnim.SetBool("walking", true);

        	transform.rotation = Quaternion.Euler(0f, walkInput * -90f, 0f); // rotate Right
        	rbody.AddForce(moveSpeed*walkInput*Time.deltaTime, 0f, 0f);
        	print("Right");
        }
        //walk left
        else if(walkInput < 0f){
        	playerAnim.SetBool("walking", true);
        	transform.rotation = Quaternion.Euler(0f, walkInput * -90f, 0f); // rotate Left
        	rbody.AddForce(moveSpeed*walkInput*Time.deltaTime, 0f, 0f);
        	print("Left");
        }
        else{
        	playerAnim.SetBool("walking", false);
        	transform.rotation = Quaternion.Euler(0f, 0f, 0f); // rotate Right

        	walkInput = 0;
        	rbody.AddForce(moveSpeed*walkInput*Time.deltaTime, 0f, 0f);
        	print("Staying still"); 
        }
 
        //playerAnim.SetBool("walking", true); 
    }

    void OnCollisionEnter(Collision other){

     if(other.gameObject.CompareTag("Ground")){
     	//print("touch ground"); 
     	rbody.drag = 10f;
 	}

 	}





}
