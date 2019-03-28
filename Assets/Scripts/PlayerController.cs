using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController2D controller;    //referencia al objeto controlador

    public Animator animator;   //referencia al Animator que usaremos para cambiar el valor de la variable Speed que controla nuestro paso de animaciones.

    public float velocity = 40f; //velocidad a la que se mueve el jugador

    float movimientoHorizontal = 0; //valor entre [-1,1] que viene del Input

    bool salto = false;

    bool agachado = false;


    // Update is called once per frame
    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocity;

        animator.SetFloat("Speed", Mathf.Abs(movimientoHorizontal));

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJumping", true);
            salto = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            agachado = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            agachado = false;
        }
    }

    void FixedUpdate()
    {
        //Mover al personaje
        //Time.fixedDeltaTime se usa para que no importe lo rápido que sea tu ordenador. Es el tiempo entre un frame y otro

        controller.Move(movimientoHorizontal * Time.fixedDeltaTime, agachado, salto);
        salto = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
