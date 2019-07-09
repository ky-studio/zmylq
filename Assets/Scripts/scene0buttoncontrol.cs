using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Timers;

public class scene0buttoncontrol : MonoBehaviour
{
    // Start is called before the first frame update
    Time tm;
    float lasttime;
    //float curtime;
    bool jump;
    void Start()
    {
        //curtime = 0;
        lasttime = 0;
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(jump==true&&Time.time - lasttime > 3.0f)
        {
            Debug.Log("lasttime:" + lasttime + " curtime:" + Time.time);
            SceneManager.LoadScene("scene1");
        }
    }
    public void OnClickButtonStartGame()
    {
        jump = true;
        GameObject block = GameObject.Find("block");
        lasttime = Time.time;
       // block.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        //block.GetComponent<RectTransform>().position = new Vector3(0.0f, 0.0f, 0.0f);
        block.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        Debug.Log(block.transform.position);
        // SceneManager.LoadScene("scene1");
       


    }
    public void OnClickButtonExitGame()
    {
        Application.Quit();
    }
    public void OnClickButtonSet()
    {

    }
    public void OnClickSaveLoad()
    {
        //GameObject block = GameObject.Find("block");
       // lasttime = Time.time;
       // block.transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        


        SceneManager.LoadScene("sceneSaveLoadstart");
    }
}
