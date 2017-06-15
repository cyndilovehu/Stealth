using UnityEngine;
using System.Collections;

public class AlarmLight : MonoBehaviour {

    public float fadeSpeed = 2f;//衰弱速度
    public float highIntensity = 2f;//灯光强度范围
    public float lowIntensity = 0.5f;//灯光强度范围
    public float changeMaragin = 0.2f;//改变灯光变化方向的阈值
    public bool alarmOn;//警报灯是否开启

    private float targetIntensity;
    private Light alarm;
    void Awake()
    {
        //初始化警报灯光强度为0
        alarm = GetComponent<Light>();
        alarm.intensity = 0;
        //设置目标强度为最大强度
        targetIntensity = highIntensity;
    }
    void Update()
    {
        if(alarmOn)
        {
            //打开
            //通过Lerp实现灯光变化
            alarm.intensity = Mathf.Lerp(alarm.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
            CheckTargetIntensity();
        }else
        {
            //关闭
            alarm.intensity = Mathf.Lerp(alarm.intensity, 0f, fadeSpeed * Time.deltaTime);
        }
    }
    void CheckTargetIntensity()
    {
        //对比当前的强度与目标强度的差值然后改变方向
        //使用Abs获取差值
        if(Mathf.Abs(targetIntensity-alarm.intensity)<changeMaragin)
        {
            if(targetIntensity==highIntensity)
            {
                targetIntensity = lowIntensity;
            }else
            {
                targetIntensity = highIntensity;
            }
        }
    }
}
