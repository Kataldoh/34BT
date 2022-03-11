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
    public bool IsNearObstacle;

    [Header("Check per il movimento")]
    public bool MoveFront;
    public bool MoveBack;
    public bool MoveLeft;
    public bool MoveRight;

   


    [Header("Velocit� player")]
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
       



        Movement();

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);


    }

    public void Movement()
    {


        if (Vector3.Distance(transform.position, movePoint.position) == 0f)
        {

            if ((Input.GetAxisRaw("Horizontal")) == 1f && CanMoveRight)
            {
                MoveRight = true;
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

            }
            else
            {
                MoveRight = false;

            }


            if ((Input.GetAxisRaw("Horizontal")) == -1f && CanMoveLeft)
            {
                MoveLeft = true;
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

            }
            else
            {
                MoveLeft = false;

            }


            if ((Input.GetAxisRaw("Vertical")) == 1f && CanMoveFront)
            {

                MoveFront = true;
                movePoint.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));


            }
            else
            {
                MoveFront = false;
            }


            if ((Input.GetAxisRaw("Vertical")) == -1f && CanMoveBack)
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

   
}
