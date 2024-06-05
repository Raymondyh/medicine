using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] YinYangMananger yy;
    [SerializeField] GameObject YinYangText;
    [SerializeField] GameObject CheckImage;
    [SerializeField] GameObject infor1;
    [SerializeField] GameObject infor2;
    bool isShowen1;
    bool isShowen2;
    bool isShowen3;

    private void Awake()
    {
        isShowen1 = false;
        isShowen2 = false;
        isShowen3 = false;
    }
    private float showTime = 1f;
    public void closeinfor1()
    {
        infor1.SetActive(false);
        //print("sd");
        Time.timeScale = 1f;
    }
    public void closeinfor2()
    {
        infor2.SetActive(false);
        Time.timeScale = 1f;
    }
    public void showinfor1()
    {
        infor1.SetActive(true);
        //print("sd");
        Time.timeScale = 0f;
    }
    public void showinfor2()
    {
        infor2.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ShowText1()
    {
        YinYangText.SetActive(true);
    }
    public void ShowText2()
    {
        YinYangText.SetActive(true);
        //YinYangText.
    }
    public void ShowText3()
    {
        YinYangText.SetActive(true);
    }
    public void CloseText()
    {
        YinYangText.SetActive(false);
    }
    
    public void ShowCheckiImage()
    {
        CheckImage.SetActive(true);
    }
    public void CloseCheckiImage()
    {
        CheckImage.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            infor1.SetActive(true);
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            infor2.SetActive(true);
            Time.timeScale = 0f;
        }
        if (yy.Persent()>=25&&!isShowen1&&yy.Persent()<50)
        {
            ShowText1();
            //print("211");
            isShowen1 = true;
        }

        if(isShowen1)
        showTime -= Time.deltaTime;

        if(showTime<=0)
        {
            CloseText();
            showTime = 1f;
        }

        if (yy.Persent() >= 50 && !isShowen2&& yy.Persent()<75)
        {
            ShowText2();
            //print("211");
            isShowen2 = true;
            showTime = 2f;
        }

        if (isShowen2)
            showTime -= Time.deltaTime;

        if (showTime <= 0)
        {
            CloseText();
            
        }

        if (yy.Persent() >= 75 && !isShowen3)
        {
            ShowText3();
            //print("211");
            isShowen3 = true;
            showTime = 4f;
        }
        if (yy.Persent() >= 0 && yy.Persent() <= 10)
        {
            isShowen1 = false;
            isShowen2 = false;
            isShowen3 = false;
        }
        if (isShowen3)
            showTime -= Time.deltaTime;

        
    }
}
