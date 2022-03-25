

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour
{
    public static GameController instance;

    [Header("Chanche di incontri con i mob")]
    [Range(0f,100f)]
    public float randomEncounterChance;

    [Header("Lista di mob presenti nel livello")]
    public GameObject[] monsterList;

    [Header("Script del player")]
    public PlayerController mainPlayerScript;
    [Space]
    [Space]
    [Space]
    public GameObject post_processing;
    [Space]
    [Space]
    public GameObject player;

    [Header("Stati di gioco")]
    public GameState _state;

    [Header("Stati del player")]
    public PlayerState _playerState;

    [Header("Pannelli UI")]
    public GameObject[] pannelli;

    StatesEvents _estates;

    private void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        post_processing = GameObject.FindGameObjectWithTag("P.Process");
        instance = this;


        //**************** SAVE DATA TO PLAYER PREFS;
        //PlayerPrefs.SetInt("quality", 3);
        //DontDestroyOnLoad(this.gameObject);

    }


    // Start is called before the first frame update
    void Start()
    {
        _state = GameState.play;
        _estates = new StatesEvents();





    }

    // Update is called once per frame
    void Update()
    {
        if (randomEncounterChance > 100f)
        {
            randomEncounterChance = 100f;
        }
      

      

        States();



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameController.instance._state == GameState.pause)
            {
                GameController.instance._state = GameState.play;
                Debug.Log("RESUMING");

            }
            else
            {
                GameController.instance._state = GameState.pause;

            }

        }




    }

    

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Resume()
    {
        Debug.Log("RESUMING");

        GameController.instance._state = GameState.play;

    }

    public void Quit()
    {
        Debug.Log("QUITTING");
        Application.Quit();
    }


    public void States()
    {
        switch (_state)
        {      

            case GameState.play:
                _estates._PLAY();
                break;

            case GameState.dead:
                _estates._DEAD();
                break;

            case GameState.pause:
                _estates._PAUSE();
                break;

   

        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Metodi Generici
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 

    public void UpdateEncounterChance()
    {

    }

    /*
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        BarraVita.SetHealth(CurrentHealth);
    }

    */


}
