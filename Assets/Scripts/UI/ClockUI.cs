using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClockUI : MonoBehaviour
{
    private const float REAL_SECONDS_PER_INGAME_DAY = 360f;

    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;
    private Text timeText;
    private float day;

    private void Awake()
    {
        clockHourHandTransform = transform.Find("hourHand");
        clockMinuteHandTransform = transform.Find("minuteHand");
        timeText = transform.Find("timeText").GetComponent<Text>();
    }

    private void Update()
    {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

        float dayNormalized = day % 1f;

        float rotationDegreesPerDay = 360f;
        clockHourHandTransform.eulerAngles = new Vector3(0, 0, 132 - dayNormalized * rotationDegreesPerDay);

        float hoursPerDay = 24f;
        clockMinuteHandTransform.eulerAngles = new Vector3(0, 0, -131 - dayNormalized * rotationDegreesPerDay * hoursPerDay);

        string hoursString = Mathf.Floor(dayNormalized * 24f).ToString("00");

        float minutesPerHour = 60f;
        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        timeText.text = hoursString + ":" + minutesString;
    }
}
