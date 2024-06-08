using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayManager : MonoBehaviour
{
    public GameObject howToPlayPanel;

    void Start()
    {
        howToPlayPanel.SetActive(false);
    }

    public void ToggleHowToPlay()
    {
        howToPlayPanel.SetActive(!howToPlayPanel.activeSelf);
    }

    public void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
    }
}
