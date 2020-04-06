using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

//ノベルエンジン by Tanje_Ln()


public class EngineText : MonoBehaviour
{
    public TextAsset Script;
    public string[] line;
    public string line2,dir;
    string scLine;
    public TextMesh serif, namae;
    public int Delay, textspeed, status = 0;
    public GameObject p1, p2, p3, p4, p5, bg;
    int index;
    int[] roots;
    public bool pressed;
    bool paused;
    int textindex=0;
    GameObject branch;
    int receive;

    // Assets/
    public Texture2D LoadTexture(string FilePath)
    {

        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails

        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        return null;                     // Return null if load failed
    }
    public Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f, SpriteMeshType spriteType = SpriteMeshType.Tight)
    {
        // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
        Texture2D SpriteTexture = LoadTexture(FilePath);
        Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit, 0, spriteType);

        return NewSprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        line = File.ReadAllLines(AssetDatabase.GetAssetPath(Script));
        index = 0;
        pressed = false;
        paused = false;
        status = 1;
        
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && pressed == false)
            pressed = true;

        if (status == 1 && line[index].Length >= 4)
            switch (line[index].Substring(0, 4))
            {
                case "<t0>": //normal Dialog
                    status = 0;
                    textindex = 0;
                    line2 = line[index].Substring(4);
                    break;
                case "<t1>": //nams Slot
                    if (line[index].Substring(4) != null)
                        namae.text = line[index].Substring(4);
                    index++;
                    break;
                case "<bg>": //change Background
                    bg.GetComponent<SpriteRenderer>().sprite = LoadNewSprite(line[index].Substring(4));
                    bg.GetComponent<Transform>().position = new Vector3(-8, -6, 5);
                    bg.GetComponent<Transform>().localScale = new Vector3(2.3f, 2.3f, 1);

                    index++;
                    break;
                case "<bm>": //Music change
                    break;
                case "<p1>": //Change Pic1
                    p1.GetComponent<SpriteRenderer>().sprite = LoadNewSprite(line[index].Substring(4));
                    index++;
                    break;
                case "<p2>": //Change Pic2
                    p2.GetComponent<SpriteRenderer>().sprite = LoadNewSprite(line[index].Substring(4));
                    index++;
                    break;
                case "<p3>": //Change Pic2
                    p3.GetComponent<SpriteRenderer>().sprite = LoadNewSprite(line[index].Substring(4));
                    index++;
                    break;
                case "<p4>": //Change Pic2
                    p4.GetComponent<SpriteRenderer>().sprite = LoadNewSprite(line[index].Substring(4));
                    index++;
                    break;
                case "<p5>": //Change Pic2
                    p5.GetComponent<SpriteRenderer>().sprite = LoadNewSprite(line[index].Substring(4));
                    index++;
                    break;
                case "<s1>": //Move Pic1
                    line2 = line[index].Substring(4);
                    string[] temp1 = line2.Split('\x020');
                    float xAxis1, yAxis1, zAxis1;
                    xAxis1 = float.Parse(temp1[0]);
                    yAxis1 = float.Parse(temp1[1]);
                    zAxis1 = float.Parse(temp1[2]);
                    p1.GetComponent<Transform>().transform.localPosition = new Vector3(xAxis1 / 100.0f, yAxis1 / 100.0f, zAxis1);
                    index++;
                    break;
                case "<s2>": //Move Pic2
                    line2 = line[index].Substring(4);
                    string[] temp2 = line2.Split('\x020');
                    float xAxis2, yAxis2, zAxis2;
                    xAxis2 = float.Parse(temp2[0]);
                    yAxis2 = float.Parse(temp2[1]);
                    zAxis2 = float.Parse(temp2[2]);
                    p2.GetComponent<Transform>().transform.localPosition = new Vector3(xAxis2 / 100.0f, yAxis2 / 100.0f, zAxis2);
                    index++;
                    break;
                case "<s3>": //Move Pic1
                    line2 = line[index].Substring(4);
                    string[] temp3 = line2.Split('\x020');
                    float xAxis3, yAxis3, zAxis3;
                    xAxis3 = float.Parse(temp3[0]);
                    yAxis3 = float.Parse(temp3[1]);
                    zAxis3 = float.Parse(temp3[2]);
                    p3.GetComponent<Transform>().transform.localPosition = new Vector3(xAxis3 / 100.0f, yAxis3 / 100.0f, zAxis3);
                    index++;
                    break;
                case "<s4>": //Move Pic2
                    line2 = line[index].Substring(4);
                    string[] temp4 = line2.Split('\x020');
                    float xAxis4, yAxis4, zAxis4;
                    xAxis4 = float.Parse(temp4[0]);
                    yAxis4 = float.Parse(temp4[1]);
                    zAxis4 = float.Parse(temp4[2]);
                    p2.GetComponent<Transform>().transform.localPosition = new Vector3(xAxis4 / 100.0f, yAxis4 / 100.0f, zAxis4);
                    index++;
                    break;
                case "<s5>": //Move Pic2
                    line2 = line[index].Substring(4);
                    string[] temp5 = line2.Split('\x020');
                    float xAxis5, yAxis5, zAxis5;
                    xAxis5 = float.Parse(temp5[0]);
                    yAxis5 = float.Parse(temp5[1]);
                    zAxis5 = float.Parse(temp5[2]);
                    p2.GetComponent<Transform>().transform.localPosition = new Vector3(xAxis5 / 100.0f, yAxis5 / 100.0f, zAxis5);
                    index++;
                    break;
                case "<go>":
                    int newindex = 0;
                    newindex = int.Parse(line[index].Substring(4));
                    index = newindex;
                    break;
                case "<tx>":
                    int newsize = int.Parse(line[index].Substring(4));
                    serif.fontSize = newsize;
                    break;
                case "<sl>":
                    line2 = line[index].Substring(4);
                    status = 3;
                    transform.Find("Branch").gameObject.SetActive(true);
                    branch = GameObject.Find("Branch");
                    branch.SendMessage("receive", line2);
                    index++;
                    break;
                default:
                    index++;
                    break;
            }
        else if (status == 0)
        {
            serif.text = line2.Substring(0, textindex).Replace(';', '\n');
            if (pressed == true)
            {
                textindex = line2.Length;
                pressed = false;
            }
            else
            {
                if (line2.Length > textindex)
                {
                    if (Delay <= textspeed)
                    {
                        textindex++;
                        textspeed = 0;
                    }
                }
                else
                {
                    status = 2;
                }
            }

            textspeed++;
        }
        else if (status == 2)
        {
            if (pressed == true)
            {
                pressed = false;
                index++;
                status = 1;
            }
            else
            {

            }
        }
        else if (status == 3)
        {

        }
        else
        {
            index++;
        }
        /*
        ルール
        <t0> - セリフ
        <t1> - 名前
        <bg> - 背景
        <bm> - 音楽
        <se> - 効果音
        <p1>~<p5> - 変更 ( ファイル見つからなかったら null )
        <s1>~<s5> - 画像の移動 ( 例: <s1>600 400 → 6.00*4.00 / x,yは元々float形なので intから変換)
        

        status変数 0 - 入力待機 / 1 - 出力中（セリフ、画像など）
        セリフの出力効果は substring, 画像の移動は timeの値と 現在、予想位置を保存して移動
        status==1の時、 inputで出力や画像の移動進行スキップ
        status==1の時のみinputで次の行を実行する。

     */
    }
    void receiveBr(int sel)
    {
        string[] temp = line[index].Split('\x020');
        index = int.Parse(temp[sel]);
        status = 1;
        pressed = false;
    }
}