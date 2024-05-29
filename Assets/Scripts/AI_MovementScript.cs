using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class AI_Movement : MonoBehaviour
{
 
    Animator animator;
 
    public float moveSpeed = 0.2f;
 
    Vector3 stopPosition;
 
    float walkTime;
    public float walkCounter;
    float waitTime;
    public float waitCounter;
    Quaternion rotationTime;
    int WalkDirection;
    Quaternion targetRotation;
    public bool isWalking;
 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
 
        //So that all the prefabs don't move/stop at the same time
        walkTime = Random.Range(3,6);
        waitTime = Random.Range(5,7);
        rotationTime = targetRotation;

 
 
        waitCounter = waitTime;
        walkCounter = walkTime;
 
    }
 
    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            animator.SetBool("isRunning", true);

            walkCounter -= Time.deltaTime;


            transform.localRotation = Quaternion.Slerp(transform.rotation, targetRotation, 100);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;

        
            if (walkCounter <= 0)
            {
                stopPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                isWalking = false;
                //stop movement
                transform.position = stopPosition;
                animator.SetBool("isRunning", false);
                //reset the waitCounter
                waitCounter = waitTime;
            }
 
 
        }
        else
        {

            waitCounter -= Time.deltaTime;
 
            if (waitCounter <= 0)
            {
                ChooseDirection();
            }
        }
    }
 
 
    public void ChooseDirection()
    {
        targetRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
        isWalking = true;
        walkCounter = walkTime;
    }
}