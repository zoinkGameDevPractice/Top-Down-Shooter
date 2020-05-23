using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    public float timeDelay = 1;

    public delegate void OnFinishedTimeStop();
    public OnFinishedTimeStop onFinishedTimeStop;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1f;
    }

    public IEnumerator StopTime()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(timeDelay);
        onFinishedTimeStop.Invoke();
    }
}
