﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HeartRate : MonoBehaviour {

    // Use this for initialization
    public float radius = 1.0f;
    public Image objHR;
    public float heartRate;
    public ColorCode cc;
    public GameObject bl_main;
    public CommonData commonData;
    void Start () {
        commonData = CommonData.GetInstance();
    }
	
	// Update is called once per frame
	void Update () {

        heartRate = commonData.HeartRateValue;
        radius = (bl_main.GetComponent<BL_Main>().bl_scaling.scallingHeartRate())/100;

        if (heartRate >= commonData.HeartRateHiHiDB && heartRate <= commonData.HeartRateHiHiSP)
        {
            // Debug.Log("HH");
            cc.LLCol();
            objHR.color = cc.LLColor;
        }
        else if (heartRate >= commonData.HeartRateHiDB && heartRate <= commonData.HeartRateHiSP)
        {
            // Debug.Log("H");
            cc.LCol();
            objHR.color = cc.LColor;
        }
        else if (heartRate <= commonData.HeartRateHiDB && heartRate >= commonData.HeartRateLoDB)
        {
            // Debug.Log("Ideal");
            cc.HCol();
            objHR.color = cc.HColor;
        }
        else if (heartRate >= commonData.HeartRateLoSP && heartRate <= commonData.HeartRateLoDB)
        {
            //Debug.Log("L");
            cc.LCol();
            objHR.color = cc.LColor;
        }
        else if (heartRate >= commonData.HeartRateLoLoSP && heartRate <= commonData.HeartRateLoLoDB)
        {
            // Debug.Log("LL");
            cc.LLCol();
            objHR.color = cc.LLColor;
        }

            objHR.transform.localScale = new Vector3(radius, radius, 1.0f);
    }
}

