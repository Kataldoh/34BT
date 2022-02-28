using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Check per lo spazio circostante")]
    public bool CanMoveFront = true;
    public bool CanMoveBack = true;
    public bool CanMoveLeft = true;
    public bool CanMoveRight = true;

    [Header("Check per il movimento")]
    public bool MoveFront;
    public bool MoveBack;
    public bool MoveLeft;
    public bool MoveRight;

    [Header("Trigger per le collisioni")]
    public BoxCollider CheckRight;
    public BoxCollider CheckLeft;
    public BoxCollider CheckFront;
    public BoxCollider CheckBack;


    [Header("Velocità player")]
    public float moveSpeed = 3f;

    [Header("Oggetto che determina lo spostamento")]
    public Transform movePoint;

    [Header("Layer da associare alle collisioni")]
    public LayerMask whatStopsMovement;

    


    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1f, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward) * 1f, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1f, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1f, Color.red);

        

        Movement();

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        
    }

    public void Movement()
    {


        if (Vector3.Distance(transform.position, movePoint.position) == 0f)
        {

            if ((Input.GetAxisRaw("Horizontal")) == 1f)
            {
                MoveRight = true;
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

            }
            else
            {
                MoveRight = false;

            }


            if ((Input.GetAxisRaw("Horizontal")) == -1f)
            {
                MoveLeft = true;
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

            }
            else
            {
                MoveLeft = false;

            }


            if ((Input.GetAxisRaw("Vertical")) == 1f)
            {

                MoveFront = true;
                movePoint.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));


            }
            else
            {
                MoveFront = false;
            }


            if ((Input.GetAxisRaw("Vertical")) == -1f)
            {

                MoveBack = true;
                movePoint.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));


            }
            else
            {
                MoveBack = false;
            }
        }
    }

    public void CheckSurrounding()
    {
        
    }
}
