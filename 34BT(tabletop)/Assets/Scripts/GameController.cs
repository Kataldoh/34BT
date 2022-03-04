using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject post_processing;
    public GameObject player;

   
    public GameState _state;
    public GameObject[] pannelli;

    StatesEvents _estates;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //BarraBoss = GameObject.FindGameObjectWithTag("Boss UI");
        post_processing = GameObject.FindGameObjectWithTag("P.Process");
        instance = this;


        DontDestroyOnLoad(this.gameObject);

    }


    void Start()
    {
        _state = GameState.play;
        _estates = new StatesEvents();



        
    }

    void Update()
    {
       
        States();

        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameController.instance._state == GameState.pause)
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


    public void States() {
        switch (_state)
        {


            case GameState.play:
                _estates._PLAY();
                break;

         

            case GameState.pause:
                _estates._PAUSE();
                break;


        }
    }

   
   

   

   
}

