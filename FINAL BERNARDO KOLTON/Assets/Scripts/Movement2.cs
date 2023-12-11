using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{ 
public float VelocidadMovimiento = 5.0f;
public float VelocidadRotacion = 200.0f;
private Animator anim;
public float x, y;
private CharacterController controller;
void Start()
{
    anim = GetComponent<Animator>();
    controller = GetComponent<CharacterController>();
}


void Update()
{
    x = Input.GetAxis("Horizontal");
    y = Input.GetAxis("Vertical");

    transform.Rotate(0, x * Time.deltaTime * VelocidadRotacion, 0);
    transform.Translate(0, 0, y * Time.deltaTime * VelocidadMovimiento);


   
}
}
