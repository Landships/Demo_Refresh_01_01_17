using UnityEngine;
using System.Collections;
using DaiMangou.RadarBuilder2D;

public class LerpValue : MonoBehaviour
{

    [TextArea(10, 100)]
    public string Info = " ";

    public _2DRadar _2DRadar_;
    private bool scaleUp;
    float t;
    public float min = 170, max = 800;

    public bool start;

    public void AutoToggle(int i)
    {
        start = !start;
    }

    void Update()
    {

        if (start)
        {

            if (_2DRadar_)
            {
                if (_2DRadar_.RadarDesign.SceneScale == min)
                {
                    scaleUp = true;
                    t = 0;
                }
                if (_2DRadar_.RadarDesign.SceneScale == max)
                {
                    scaleUp = false;
                    t = 0;
                }
                t += 0.15f * Time.deltaTime;
                if (scaleUp)
                    _2DRadar_.RadarDesign.SceneScale = Mathf.Lerp(min, max, t);
                else
                    _2DRadar_.RadarDesign.SceneScale = Mathf.Lerp(max, min, t);
            }
        }
    }

}
