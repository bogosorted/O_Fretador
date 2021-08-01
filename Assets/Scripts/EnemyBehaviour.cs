//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyBehaviour : MonoBehaviour
//{
    
//    [SerializeField, Range(0f, 10f)] public float speed;
//    float atualState, speedRotation;
//    float minValue, maxValue;
//    private float cd;
//    private float numero;
//    private bool ancorado, navioDireita, rotationOn, inicioAnim;
//    [SerializeField] private GameObject player, raycastPosition;
//    [SerializeField] private CanhaoBehaviour canhaoL, canhaoR;
//    private Vector3 position;
//    private Transform aguaN, aguaS, aguaL, aguaO;
//    private Quaternion ang, angPai;
    
//    private void Start()
//    {
//	aguaN.rotation = Quaternion.Euler(0,0, 0);
//	aguaS.rotation = Quaternion.Euler(0,0, 180);
//	aguaL.rotation = Quaternion.Euler(0,0, 90);
//	aguaO.rotation = Quaternion.Euler(0,0, 270);
//	rotationOn = true;
//	position = raycastPosition.transform.position;
//	cd = 0;
//        ancorado = true;
//        atualState = 0;
//    }
//    void FixedUpdate()
//    {
//	RaycastShoot();
//	RaycastActive();
//	if(!ancorado)
//	{
//	    Move();
//	    Rotate();
//	}
//    }
//    private void Rotate()   
//    {
//	numero = Mathf.SmoothStep(0, 1, 5 * Time.deltaTime);
//	switch(GeraMapa.aguaAtual.rotation)
//	{
//	    case AguaS:
//		ang = Quaternion.Euler(-180,10,-90);
//		angPai = Quaternion.Euler(0,0,-60);
//		break;   
//	}
//        transform.localRotation = Quaternion.Slerp(transform.localRotation, ang, numero);
//	transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, angPai, numero);
//    } 
//    private void Move()
//    {
//        transform.parent.Translate(Vector3.up * speed / 100, Space.Self);
//    }
//    private void RaycastActive()
//    {
//        if(Physics.Raycast(position, Vector3.right, Mathf.Infinity, LayerMask.GetMask("Navio")))
//        {
//	    navioDireita = true;
//            ancorado = false;
//        }
//	if(Physics.Raycast(position, Vector3.left, Mathf.Infinity, LayerMask.GetMask("Navio")))
//	{
//	    navioDireita = false;
//	    ancorado = false;
//	}
//    }
//    private void RaycastShoot()
//    {
//	if(Time.time > cd)
//	{
//	     if(Physics.Raycast(transform.position, Vector3.right, Mathf.Infinity, LayerMask.GetMask("Navio")))
//             {
//		print("atirar " + Time.time);
//	     	canhaoR.Ativado = true;
//             	canhaoR.Interact();
//                cd = Time.time + 5f;
//             }
//             if(Physics.Raycast(transform.position, Vector3.left, Mathf.Infinity, LayerMask.GetMask("Navio")))
//             {
//		print("atirar " + Time.time);
//             	canhaoL.Ativado = true;
// 	     	canhaoL.Interact();
//                cd = Time.time + 5f;
//             }
//	}
//    }
//}
