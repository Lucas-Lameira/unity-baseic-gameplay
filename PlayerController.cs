using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    //private Rigidbody playerRigidBody;
    //private float horizontalInput = 0f;
    //private float verticalInput = 0f;
    //public float speed = 10.0f;
    //public float jumpSpeed = 20.0f;
    //public float rotateSpeed = 100.0f;
    //public float rotationSpeed = 100.0f;


    private bool teclaSaltoFoiPressionada;
    private float entradaEixoHorizontal;
    private Rigidbody playerRigidBody;
    [SerializeField] private Transform baseHeroi;
    [SerializeField] private LayerMask mascaraCamada;
    //private bool naPlataforma;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            teclaSaltoFoiPressionada = true;
        }
        entradaEixoHorizontal = Input.GetAxis("Vertical");
    }   

    private void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector3(
            entradaEixoHorizontal * 6, 
            playerRigidBody.velocity.y, 0
        );

        /* 1 tipo de colisão (Collision)
        if(!naPlataforma){return;}*/
        
        /*2 tipo de colisão (OverlapSphere)
        if(Physics.OverlapSphere(baseHeroi.position, 0.2f).Length == 1) {return;} */
        
        //3 tipo de colisão (Layers)
        if(Physics.OverlapSphere(baseHeroi.position, 0.2f, mascaraCamada).Length == 0)
        {
            return;
        }

        //5 é a distancia do salto
        if(teclaSaltoFoiPressionada == true){
            playerRigidBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            teclaSaltoFoiPressionada = false;
        }
    }

    private void OnTriggerEnter(Collider other){
        Destroy(other.gameObject);
    }

    /*
    public void OnCollisionEnter(Collision collision){
        //Colide
        naPlataforma = true;
    }
    public void OnCollisionExit(Collision collision){
        //não colide
        naPlataforma = false;
    }
    */
}
