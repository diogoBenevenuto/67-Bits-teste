using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;

    [Header("Config Player")]
    public float movementSpeed = 3f;
    
    private Vector3 direction;
    private bool IsWalk;

    [Header("Camera")]
    public GameObject camB;
    void Start()
    {
       controller = GetComponent<CharacterController>();
       anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction = new Vector3(horizontal, 0f, vertical).normalized;
        if(direction.magnitude > 0.1f)
        {
            //calculo do angulo que estou  me movendo (em radiano) e na '*' esta convertendoo radiano para graus
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            IsWalk = true;
        
        }
        else
        {
            IsWalk = false;
        }

        controller.Move(direction * movementSpeed * Time.deltaTime);
        anim.SetBool("IsWalk", IsWalk);
    }

// ---------- Controle da Camera para focar dinamica ---------------
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "CamTrigger":
                camB.SetActive(true);
                break;
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        switch(other.gameObject.tag)
        {
            case "CamTrigger":
                camB.SetActive(false);
                break;
        }
    }
}
