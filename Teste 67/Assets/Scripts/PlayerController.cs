using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    [Header("Config Player")]
    public float movementSpeed = 3f;
    
    private Vector3 direction;
    void Start()
    {
       controller = GetComponent<CharacterController>();
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
        }

        controller.Move(direction * movementSpeed * Time.deltaTime);
    }
}
