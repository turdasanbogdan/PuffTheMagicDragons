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
    	moveSpeed = 1500f;
        
    }

    // Update is called once per frame
    void Update()
    {
        float walkInput = Input.GetAxis("Horizontal"); // get left-right buttons
        float frontInput = Input.GetAxis("Vertical");
		Vector3 forward = transform.TransformDirection(Vector3.forward);

        //walk right
        if(walkInput > 0f ){
            

        	playerAnim.SetBool("running", true);

        	transform.rotation = Quaternion.Euler(0f, walkInput * 90f, 0f); // rotate Right 
        	rbody.AddForce(moveSpeed*walkInput*Time.deltaTime, 0f, 0f);
        	print("Right");
           
        }
        //walk left
        else if(walkInput < 0f){
        	playerAnim.SetBool("running", true);
        	transform.rotation = Quaternion.Euler(0f, walkInput * 90f, 0f); // rotate Left
        	rbody.AddForce(moveSpeed*walkInput*Time.deltaTime, 0f, 0f);
        	print("Left");
          
        }
        //walk forward
        else if(frontInput > 0f){
            playerAnim.SetBool("running", true);
        	rbody.AddForce(forward * moveSpeed * Time.deltaTime );
        	print("front");
            

        }
        else if(frontInput < 0f){
            playerAnim.SetBool("running", false);
        }

        else{
           
        	playerAnim.SetBool("running", false);
        	transform.rotation = Quaternion.Euler(0f, 0f, 0f); // rotate Right

        	walkInput = 0;
        	rbody.AddForce(moveSpeed*walkInput*Time.deltaTime, 0f, 0f);
        	print("Staying still"); 
        }

 
       
        // if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
		// 	Move(MazeDirection.North);
		// }
		// else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
		// 	Move(MazeDirection.East);
		// }
		// else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
		// 	Move(MazeDirection.South);
		// }
		// else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
		// 	Move(MazeDirection.West);
		// }
		// else if (Input.GetKeyDown(KeyCode.Q)) {
		// 	Look(currentDirection.GetNextCounterclockwise());
		// }
		// else if (Input.GetKeyDown(KeyCode.E)) {
		// 	Look(currentDirection.GetNextClockwise());
		// }
    }

    void OnCollisionEnter(Collision other){

     if(other.gameObject.CompareTag("Ground")){
     	//print("touch ground"); 
     	rbody.drag = 10f;
 	}

 	}





}