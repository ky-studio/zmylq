using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveLoadControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static int choosefilenum;//默认选择的操作对象
    public string preScene;//代表着原先的场景
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;
    public float a;
    void Start()
    {
        choosefilenum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickButtonReturnGame()//返回游戏
    {
        //SceneManager.LoadScene("scene2",LoadSceneMode.Additive);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("scene2"));
        // SceneManager.UnloadScene(SceneManager.GetSceneByName("sceneSaveLoad"));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("sceneSaveLoad"));
        //SceneManager.LoadScene("scene0");
    }
    public void OnClickButtonReturnMenu()
    {
        SceneManager.LoadScene("scene0");
    }
    public void OnClickButtonFile1()
    {
        ChooseFile(1);
    }
    public void OnClickButtonFile2()
    {
        ChooseFile(2);
    }
    public void OnClickButtonFile3()
    {
        ChooseFile(3);
    }
    public void OnClickButtonFile4()
    {
        ChooseFile(4);
    }
    public void OnClickButtonFile5()
    {
        ChooseFile(5);
    }
    public void OnClickButtonFile6()
    {
        ChooseFile(6);
    }

    public void OnClickButtonSave()
    {               
        DateTime now = DateTime.Now;
        switch(choosefilenum)
        {
            case 1:
                text1.text = string.Format("存档{0} 章节：{1} 时间：{2}", choosefilenum, "1-2", now.ToString("yyyy/MM/dd hh:mm"));
                break;
            case 2:
                text2.text = string.Format("存档{0} 章节：{1} 时间：{2}", choosefilenum, "1-2", now.ToString("yyyy/MM/dd hh:mm"));
                break;
            case 3:
                text3.text = string.Format("存档{0} 章节：{1} 时间：{2}", choosefilenum, "1-2", now.ToString("yyyy/MM/dd hh:mm"));
                break;
            case 4:
                text4.text = string.Format("存档{0} 章节：{1} 时间：{2}", choosefilenum, "1-2", now.ToString("yyyy/MM/dd hh:mm"));
                break;
            case 5:
                text5.text = string.Format("存档{0} 章节：{1} 时间：{2}", choosefilenum, "1-2", now.ToString("yyyy/MM/dd hh:mm"));
                break;
            case 6:
                text6.text = string.Format("存档{0} 章节：{1} 时间：{2}", choosefilenum, "1-2", now.ToString("yyyy/MM/dd hh:mm"));
                break;
            default:
                break;
        }
        int[] fs = { 1, 2, 3 };
        SaveInfo saveInfo = SaveLoad.SetData("张三", "scene0", "bg", "12", 10, 12, fs);
        SaveLoad.Save(choosefilenum, saveInfo);
    }

    public void OnClickButtonRead()
    {
        SaveInfo loadInfo = SaveLoad.Load(choosefilenum);
        if (loadInfo != null)
        {
            Debug.Log(loadInfo.username);
        }
    }

    private void ChooseFile(int index)
    {
        choosefilenum = index;
        GameObject[] filesix=new GameObject[6];
        filesix[0] = GameObject.Find("file1");
        filesix[1] = GameObject.Find("file2");
        filesix[2] = GameObject.Find("file3");
        filesix[3] = GameObject.Find("file4");
        filesix[4] = GameObject.Find("file5");
        filesix[5] = GameObject.Find("file6");

        for(int i=0;i<6;i++)
        {
            if(i==index-1)
            {
                filesix[i].GetComponent<Image>().color = Color.red;
            }
            else
                filesix[i].GetComponent<Image>().color = Color.white;
        }

    }
}
