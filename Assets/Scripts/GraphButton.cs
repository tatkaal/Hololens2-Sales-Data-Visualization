using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GraphButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressed()
    {
    	Scene currentScene = SceneManager.GetActiveScene ();

    	string sceneName = currentScene.name;

    	if (sceneName == "Product") 
        {
            SceneManager.LoadScene("infoscene");
        }
    }
}
