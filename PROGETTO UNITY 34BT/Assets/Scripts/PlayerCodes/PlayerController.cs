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

    [Header("Direzioni")]
    public bool FacingFront;
    public bool FacingBack;
    public bool FacingRight;
    public bool FacingLeft;


    [Header("Velocit� player")]
    public float moveSpeed = 3f;

    [Header("Velocit� rotazione player")]
    public float rotSpeed = 3f * Time.deltaTime;


    [Header("Oggetto che determina lo spostamento")]
    public Transform movePoint;



    Quaternion targetAngle_90 = Quaternion.Euler(0, 90, 0);
    Quaternion targetAngle_0 = Quaternion.Euler(0, 0, 0);
    Quaternion targetAngle_minus90 = Quaternion.Euler(0, -90, 0);
    Quaternion targetAngle_minus180 = Quaternion.Euler(0, -180, 0);

    private float rot;



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
                if(GameController.instance.randomEncounterChance!= 100f)
                {
                    GameController.instance.randomEncounterChance = GameController.instance.randomEncounterChance + Random.Range(1, 10);
                    Debug.Log("Encounter chanche is " + GameController.instance.randomEncounterChance);
                }
               
                GameController.instance._playerState = PlayerState.groundMoving;

                MoveRight = true;
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

                rot = 90f;

                Quaternion qrot = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, rot, 0), Time.deltaTime * rotSpeed);
                transform.rotation = qrot;

                FacingBack = false;
                FacingFront = false;
                FacingLeft = false;
                FacingRight = true;



            }
            else
            {
                MoveRight = false;

                GameController.instance._playerState = PlayerState.idle;

            }


            if ((Input.GetAxisRaw("Horizontal")) == -1f && CanMoveLeft)
            {
                if (GameController.instance.randomEncounterChance != 100f)
                {
                    GameController.instance.randomEncounterChance = GameController.instance.randomEncounterChance + Random.Range(1, 10);
                    Debug.Log("Encounter chanche is " + GameController.instance.randomEncounterChance);
                }

                GameController.instance._playerState = PlayerState.groundMoving;


                MoveLeft = true;
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

                rot = -90f;

                Quaternion qrot = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, rot, 0), Time.deltaTime * rotSpeed);
                transform.rotation = qrot;

                FacingBack = false;
                FacingFront = false;
                FacingLeft = true;
                FacingRight = false;

            }
            else
            {
                MoveLeft = false;
                GameController.instance._playerState = PlayerState.idle;

            }


            if ((Input.GetAxisRaw("Vertical")) == 1f && CanMoveFront)
            {

                if (GameController.instance.randomEncounterChance != 100f)
                {
                    GameController.instance.randomEncounterChance = GameController.instance.randomEncounterChance + Random.Range(1, 10);
                    Debug.Log("Encounter chanche is " + GameController.instance.randomEncounterChance);
                }

                GameController.instance._playerState = PlayerState.groundMoving;

                MoveFront = true;
                movePoint.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));


                rot = 0f;

                Quaternion qrot = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, rot, 0), Time.deltaTime * rotSpeed);
                transform.rotation = qrot;

                FacingBack = false;
                FacingFront = true;
                FacingLeft = false;
                FacingRight = false;



            }
            else
            {
                GameController.instance._playerState = PlayerState.idle;

                MoveFront = false;
            }


            if ((Input.GetAxisRaw("Vertical")) == -1f && CanMoveBack)
            {
                if (GameController.instance.randomEncounterChance != 100f)
                {
                    GameController.instance.randomEncounterChance = GameController.instance.randomEncounterChance + Random.Range(1, 10);
                    Debug.Log("Encounter chanche is " + GameController.instance.randomEncounterChance);
                }

                GameController.instance._playerState = PlayerState.groundMoving;

                MoveBack = true;
                movePoint.position += new Vector3(0f, 0f, Input.GetAxisRaw("Vertical"));

                rot = -180f; 

                Quaternion qrot = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, rot, 0), Time.deltaTime * rotSpeed);
                transform.rotation = qrot;

                FacingBack = true;
                FacingFront = false;
                FacingLeft = false;
                FacingRight = false;



            }
            else
            {
                GameController.instance._playerState = PlayerState.idle;

                MoveBack = false;

            }

            if((Input.GetAxisRaw("Vertical"))== 1 && (Input.GetAxisRaw("Horizontal")) == 1)
            {
                movePoint.position = transform.position;
            }

            if ((Input.GetAxisRaw("Vertical")) == 1 && (Input.GetAxisRaw("Horizontal")) == -1)
            {
                movePoint.position = transform.position;
            }

            if ((Input.GetAxisRaw("Vertical")) == -1 && (Input.GetAxisRaw("Horizontal")) == 1)
            {
                movePoint.position = transform.position;
            }

            if ((Input.GetAxisRaw("Vertical")) == -1 && (Input.GetAxisRaw("Horizontal")) == -1)
            {
                movePoint.position = transform.position;
            }
        }
    }

   
}
