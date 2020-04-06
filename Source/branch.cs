using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class branch : MonoBehaviour
{
    GameObject engineMain;
    public GameObject[] button;
    GameObject[] Dialogs;
    EngineText entx;
    public int num=0, num2;
    string[] code;
    bool activ = false;
    // code -> 選択肢
    // Start is called before the first frame update
    void Start()
    {
        engineMain = GameObject.FindGameObjectWithTag("Main");
        entx = engineMain.GetComponent<EngineText>();
        Dialogs = GameObject.FindGameObjectsWithTag("Dialog");
        num2 = 0;
        //num : 最大数, num2 : 選択中
        //num == num2 : 一番下の選択肢
    }

    private void Awake()
    {
        code = null;
        num = 0;
        num2 = 0;
        for (int i = 0; i < button.Length; i++)
        {
            button[i].SendMessage("settxt", "");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            num2--;
            refresh();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            num2++;
            refresh();
        }
        if (Input.GetKeyDown(KeyCode.Z)|| Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            buttonAct();
        }
    }

    void receive(string ln)
    {
        code = ln.Split('\x020');
        num = code.Length;
        for (int i = 0; i < num; i++)
        {
            button[i].SendMessage("settxt", code[i]);

        }
        refresh();

    }

    void buttonAct()
    {
        engineMain.SendMessage("receiveBr", num2);
        gameObject.SetActive(false);
        
    }
    void refresh()
    {
        num2 = (num2 + num) % num;
        for (int i = 0; i < num; i++)
        {
            button[i].SendMessage("setAlpha", 0.6f);
        }
        button[num2].SendMessage("setAlpha", 1.0f);

    }
}
