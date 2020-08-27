using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTabControl : MonoBehaviour {
    private Transform bottomUI;
    void Awake() {
        bottomUI = transform.Find("Theme_BottomUI");
        bottomUI.transform.Find("Shop").GetComponentInChildren<Toggle>().onValueChanged.AddListener(ClickShop);
        bottomUI.transform.Find("Decoration").GetComponentInChildren<Toggle>().onValueChanged.AddListener(ClickDecoration);
        bottomUI.transform.Find("Home").GetComponentInChildren<Toggle>().onValueChanged.AddListener(ClickHome);
        bottomUI.transform.Find("Activity").GetComponentInChildren<Toggle>().onValueChanged.AddListener(ClickActivities);
        bottomUI.transform.Find("Rank").GetComponentInChildren<Toggle>().onValueChanged.AddListener(ClickRank);
    }

    private void ClickRank(bool arg0)
    {
        throw new NotImplementedException();
    }

    private void ClickActivities(bool arg0)
    {
        throw new NotImplementedException();
    }

    private void ClickHome(bool arg0)
    {
        throw new NotImplementedException();
    }

    private void ClickDecoration(bool arg0)
    {
        throw new NotImplementedException();
    }

    private void ClickShop(bool arg0)
    {
        
    }
}