using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class passOn : MonoBehaviour {

    GameObject container;
	// Use this for initialization
	void Start () {

        container = GameObject.FindGameObjectWithTag("Container");
        StartCoroutine(Load("SynaptX2_0"));
    }

    IEnumerator Load(string nextScene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        print("whileschleife");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        print("New scene is loaded");


        int scenecounter = SceneManager.sceneCount; // sceneCounter = 0 -> aktive scene. sceneCounter = 1 -> naechsteScene
        SceneManager.MoveGameObjectToScene(container, SceneManager.GetSceneAt(scenecounter - 1));
        print(SceneManager.GetSceneAt(scenecounter - 1).name + " " + (scenecounter - 1));
        print(SceneManager.GetSceneAt(scenecounter - 2).name + " " + (scenecounter - 2));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(scenecounter - 2));

    }
}
