using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public float timeAnHourTakes = 5;
    public Transform minhand;
    public Transform hourhand;
    public float t;
    public int hour = 0;
    Coroutine clockrun;
    IEnumerator hourrun;

    public UnityEvent<int> OnTheHour;

    void Start()
    {
        clockrun = StartCoroutine(goingforever());
    }

    IEnumerator goingforever()
    {
        while (true)
        {
            hourrun = movetheclockonehour();
            yield return StartCoroutine(hourrun);
        }

    }

    IEnumerator movetheclockonehour()
    {
        t = 0;
        while (t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            minhand.Rotate(0, 0, -(360 / timeAnHourTakes)* Time.deltaTime);
            hourhand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null;
        }
        hour++;
        if (hour == 13)
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);
    }

    public void stopit()
    {
        if (clockrun != null)
        {
            StopCoroutine(clockrun);
        }
        if (hourrun != null)
        {
            StopCoroutine(hourrun);
        }
    }
}
