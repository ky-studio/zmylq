using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scene0buttoncontrol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickButtonStartGame()
    {
        SceneManager.LoadScene("scene1");
    }
    public void OnClickButtonExitGame()
    {
        Application.Quit();
    }
}
