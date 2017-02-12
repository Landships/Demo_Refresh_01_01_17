using UnityEngine;
using System.Collections;
using DaiMangou.RadarBuilder2D;
/// <summary>
/// With this script we will control out radars scenescale value. 
/// </summary>
public class UIRadarSliderController : MonoBehaviour
{

    [TextArea(10, 100)]
    public string Info = " ";
    public _2DRadar _2DRadar_;




    public void valueChange(float value)
    {
        // controls how muh of the blips we can see at any one time

        if (_2DRadar_)
            _2DRadar_.RadarDesign.SceneScale = value;
    }




}
