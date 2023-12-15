using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    public float movementSpeed = 3.0f;
    public float raycastDistance = 1.0f; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        Vector3 moveDirection = transform.forward;
        controller.Move(moveDirection * movementSpeed * Time.deltaTime);

        
        float speed = controller.velocity.magnitude;
        bool isWalking = speed > 0.1f; 
        animator.SetBool("IsWalk", isWalking);

        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            
            Vector3 newDirection = Vector3.Reflect(moveDirection, hit.normal);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
