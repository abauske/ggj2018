using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Containmentscript : MonoBehaviour {

    public int gameVersion;
    public int containerIndex;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Start()
    {
        SceneManager.LoadScene("MainMenu");
      /*  if( SceneManager.GetActiveScene().name.Equals( "FirstScene" ))
        {
            StartCoroutine(StarteDasSpiel("MainMenu"));
        }
        */
    }

    /*
    IEnumerator StarteDasSpiel(string nextScene)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        
        SceneManager.MoveGameObjectToScene(this.gameObject , SceneManager.GetSceneByName(nextScene));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("FirstScene"));

    }
    */

}


