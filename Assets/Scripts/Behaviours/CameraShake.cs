using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    CinemachineBasicMultiChannelPerlin noise;

    public float smallAmplitude = 1.5f;
    public float bigAmplitude = 3f;

    public float frequency = 2f;

    public float shakeDelay = 0.3f;

    public bool smallShake = false;
    public bool bigShake = false;

    private void Start()
    {
        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = frequency;
    }

    private void Update()
    {
        if (smallShake)
            StartCoroutine(SmallShake());
        if (bigShake)
            StartCoroutine(BigShake());
    }

    IEnumerator SmallShake()
    {
        smallShake = false;
        noise.m_AmplitudeGain = smallAmplitude;
        yield return new WaitForSeconds(shakeDelay);
        StopShake();
    }

    IEnumerator BigShake()
    {
        bigShake = false;
        noise.m_AmplitudeGain = bigAmplitude;
        yield return new WaitForSeconds(shakeDelay);
        StopShake();
    }

    void StopShake()
    {
        noise.m_AmplitudeGain = 0f;
    }
}
