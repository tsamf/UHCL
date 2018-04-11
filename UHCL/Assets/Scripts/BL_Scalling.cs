﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_Scalling {

    public BL_Scalling()
    {
        commonData.SuitPressureMax = 20;
        commonData.SuitPressureMin = 0;
    }

    private CommonData commonData = CommonData.GetInstance();

    //Sending out actual suitpressure value
    public float actualSuitPressure ()
    {
        return commonData.SuitPressureValue;
    }

    //Scaling from number to percentage
    public float ScalingFunction(
        )
    {
        commonData.SuitPressureValue = BLScalingLimiting(commonData.SuitPressureValue);
<<<<<<< HEAD
        float SuitPressure_normalize = (commonData.SuitPressureValue) / (commonData.SuitPressureMax - commonData.SuitPressureMin);
=======
        float SuitPressure_normalize = ((commonData.SuitPressureValue) / (commonData.SuitPressureMax - commonData.SuitPressureMin))*100;
        Debug.Log(SuitPressure_normalize);
>>>>>>> 6c225d330a02e9230c42be85b584b0485b8110a0
        return SuitPressure_normalize;
    }

    //Scaling and limiting function
    public float BLScalingLimiting(
        float DB_SuitPressure
        )
    {
        // This function is about to make sure that SuitPressure is between SuitPressureMax and SuitPressureMin
        if (DB_SuitPressure < commonData.SuitPressureMin)
            DB_SuitPressure = commonData.SuitPressureMin;
        if (DB_SuitPressure > commonData.SuitPressureMax)
            DB_SuitPressure = commonData.SuitPressureMax;
        return DB_SuitPressure;
    }

   
}
