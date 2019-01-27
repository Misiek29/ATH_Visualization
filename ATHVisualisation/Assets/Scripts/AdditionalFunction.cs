using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditionalFunction : MonoBehaviour {

    private float restartTimer;
    private bool activeRestartCanvas = false;
    private bool activePlanCanvas = false;
    public bool activeStartCanvas = true;
    private CharacterController charController;

    public GameObject RestartCanvas;
    public GameObject PlanCanvas;
    public GameObject StartMenu;

    


    public Camera cam;
    
     private void Awake()
    {
        
    }

    public float requireRestartTime;

    
	// Use this for initialization
	void Start () {

        charController = GetComponent<CharacterController>();
        cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Default"));
        cam.cullingMask ^= 1 << LayerMask.NameToLayer("Start");

        StartMenu.SetActive(true);
        charController.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("joystick button 3")) // sprawdzanie czy przycisk restartu został wciśnięty
        {
            ShowRestartCanvas(); // uruchomienie funkcji wyświetlającej komunikat
        }

        if (Input.GetKeyDown("joystick button 0")) // sprawdzanie czy przycisk planu został wciśnięty
        {
            ShowPlanCanvas();
        }


        if (Input.GetKey("joystick button 3")) // sprawdzanie czy przycisk restartu jest trzymany
          {
         
            restartTimer += Time.deltaTime; // odliczanie przez jaki czas przycisk jest wciśnięty

            if (restartTimer >= requireRestartTime) 
            {
                RestartApp(); // wywołanie funkcji restartującej aplikację
            }
          }

        if (Input.GetKeyUp("joystick button 3") )
        {
            
            ShowRestartCanvas();
        }

        if (Input.GetKeyUp("joystick button 1") && activeStartCanvas == true)
        {
            StartApp();

        }
    }

    public void ShowRestartCanvas()
    {
        if (activeRestartCanvas==false)
        {
            activeRestartCanvas = true;
            RestartCanvas.SetActive(true);

        }
        else
        {
            activeRestartCanvas = false;
            RestartCanvas.SetActive(false);
        }
    }

    public void ShowPlanCanvas()
    {
        if (activePlanCanvas == false && activeStartCanvas == false)
        {
            activePlanCanvas = true;
            PlanCanvas.SetActive(true);

        }
        else
        {
            activePlanCanvas = false;
            PlanCanvas.SetActive(false);
        }
    }

    public void StartApp()
    {
        activeStartCanvas = false;
        cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Start"));
        cam.cullingMask ^= 1 << LayerMask.NameToLayer("Default");
        charController.enabled = true;
       

    }

    public void RestartApp()
    {
        SceneManager.LoadScene("AthVisualisation");
        System.GC.Collect();
    }
}
