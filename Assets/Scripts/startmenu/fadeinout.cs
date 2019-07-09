using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class fadeinout : MonoBehaviour
{
    // Start is called before the first frame update
    public static fadeinout instance;
    public float alpaval;
    public Image im;
    public bool isfadein;
    public  bool isfadeout;

    private void Awake()
    {
        instance = this;
        isfadein = false;
        isfadeout = false;//是否是因为它的实例化的顺序更慢
        Debug.Log("fadeinoutawake()");
        im = GameObject.Find("block").GetComponent<Image>();
    }
    public fadeinout()
    {

    }
    void Start()
    {
        //isfadein = false;
        //isfadeout = false;//是否是因为它的实例化的顺序更慢
        //Debug.Log("fadeinoutstart()");
       // alpaval = 0.0f;
       // im = GameObject.Find("block").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(alpaval + " " + isfadein);
        if (alpaval < 1.0f&&isfadeout==true)
        {
            alpaval += 0.01f;
            //im.material.color = new Color(1.0f, 1.0f, 1.0f, alpaval);
            im.color= new Color(0.0f, 0.0f, 0.0f, alpaval);
        }
        else if(alpaval>0.1f&&isfadein==true)
        {
            alpaval -= 0.01f;
            //im.material.color = new Color(1.0f, 1.0f, 1.0f, alpaval);
            im.color = new Color(0.0f, 0.0f, 0.0f, alpaval);
            Debug.Log(alpaval);
        }
        else if(isfadein==true&&alpaval<=0.1f)
        {
            GameObject.Find("block").transform.localPosition=new Vector3(0.0f,1500.0f,0.0f);
        }
        
    }
   public void fadeoutset()//从最高到透明+是fadeout
    {
        alpaval =0.0f;//0是透明
        isfadeout = true;
        isfadein = false;
        Debug.Log("fadeoutset");
    }
    public void fadeinset()//+是fadeout
    {
        alpaval = 1.0f;
        isfadein = true;
        isfadeout = false;
        Debug.Log("fadeinset");
    }
}
