using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text text;

    public void Set(UpgradeData upgradeData)
    {
        icon.sprite = upgradeData.icon;
        text.text = upgradeData.text;
    }

    internal void Clean()
    {
        icon.sprite = null;
    }
}
