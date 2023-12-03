using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public TMP_Text clicksCount;
    public TMP_Text upgradeCostText;
    public TMP_Text upgradeCostText2;
    public float clicks =0f;

    private float _upgradeCost = 10f;
    private int _clickMultipliar = 1;

    private float _autoClickCost = 20f;

    private float timer = 0f;
    private float interval = 2.15f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        clicksCount.text = "Clicks: " + clicks;
        upgradeCostText.text = "Upgrade Cost: " + _upgradeCost;
        upgradeCostText2.text = "AutoClick Cost; " + _autoClickCost;

        timer += Time.deltaTime;

        // Check if the interval has passed
        if (timer >= interval)
        {
            // Call your clicker button function here
            OnClickButton();

            // Reset the timer
            timer = 0f;
        }
    }

    public void OnClickButton()
    {
        clicks = clicks + 1 * _clickMultipliar; 
    }

    public void OnUpgrade()
    {
        if (clicks >= _upgradeCost)
        {
            clicks -= _upgradeCost;
            _upgradeCost += 10;
            _clickMultipliar++;
        }
        
    }

    public void OnAutoClickButton()
    {
        if (_autoClickCost < 400){
            if (clicks >= _autoClickCost)
            {
                clicks -= _autoClickCost;
                _autoClickCost += 20;
                interval = interval / 1.15f;
            }
        }
    }
}
