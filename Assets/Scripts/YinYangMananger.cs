using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class YinYangMananger : MonoBehaviour
{
    [SerializeField] Slider Yin;
    [SerializeField] Slider Yang;
    [SerializeField] Slider Banlance;
    private int yin;
    private int yang;
    private float banlance;
    public int maxYinYnag;
    private void Awake()
    {
        Banlance.value = 100;
        Yin.maxValue = maxYinYnag;
        Yang.maxValue = maxYinYnag;
        Yin.interactable = false;
        Yang.interactable = false;
        Banlance.interactable = false;
    }
    public void IncreaseYin(int _value)
    {
        if (yin > maxYinYnag*10)
        {
            Yin.value = maxYinYnag;
            return;
        }
            

        yin += _value;
        Yin.value = yin;

        float k = 100 / maxYinYnag;
        banlance = k * (yin - yang) + 100;

        Banlance.value = banlance;
    }
    public void IncreaseYang(int _value)
    {
        if (yang > maxYinYnag*10)
        {
            Yang.value = maxYinYnag;
            return;
        }
            
        yang += _value;
        Yang.value = yang;

        float k = 100 / maxYinYnag;
        banlance = k * (yin - yang) + 100;

        Banlance.value = banlance;
    }
    public int Persent()
    {

        int diff = Mathf.Abs(yin - yang);
        //print(diff);
        float persent = (float)diff / (float)maxYinYnag;
        //print(persent);
        float res = persent * 100;
        //print(res);
        return (int)res;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            IncreaseYin(1);
            //int temp = Persent();
            //print(temp);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            IncreaseYang(1);
        }
    }
}
