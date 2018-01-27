using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuBarScript : MonoBehaviour {
    
    public EscapeMenuScript escMenu2;

    public GameObject escMenu;
    private bool escIsShowing;

    public bool globalRunning { get; private set; }

    public Knotenspawn spawner;
    
    public GameObject menuBar;
    private bool barIsShowing;

    private void Start()
    {
        escIsShowing = false;
        barIsShowing = true;
        spawner.running = true;
    }

    void FixedUpdate()
    {
        //if (Input.GetKeyDown("escape"))
        //{
        //    escIsShowing = !escIsShowing;            
        //    if (escIsShowing)
        //    {
        //        escMenu.SetActive(escIsShowing);
        //        escMenu2.moveIn();
        //    }
        //    else
        //    {
        //        escMenu2.moveOut();
        //        escMenu.SetActive(escIsShowing);
        //    }
            
        //    barIsShowing = !barIsShowing;
        //    menuBar.SetActive(barIsShowing);

        //    spawner.running = !spawner.running;

        //    globalRunning = !globalRunning;
        //}
    }
}
