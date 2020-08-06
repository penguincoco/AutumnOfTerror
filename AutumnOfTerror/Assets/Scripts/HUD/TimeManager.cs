using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    private static TimeManager _instance;
    public static TimeManager Instance { get { return _instance; } }

    public Light sun;
    public float dayAngle;
    public float eveningAngle;

    public string date_Text;
    public TextMeshProUGUI date;
    public TextMeshProUGUI timeOfDay;

    public int day;
    public string month;
    [HideInInspector]public int year = 1888;

    void Awake()
    {
        //singleton pattern
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

    }

    public void SetTime()
    {
        //if it's still daytime...
        if (timeOfDay.text.Equals("Day"))
        {
            Debug.Log("IT'S DAYTIME");
            SetDateText();

            timeOfDay.text = "Evening";
            sun.transform.eulerAngles = new Vector3(eveningAngle, 0f, 0f);
        }

        //if it was evening and time progressed, move it to the next day
        else if (timeOfDay.text.Equals("Evening"))
        {
            Debug.Log("IT'S NIGHT TIME");

            day++;

            DateOutOfBoundsCheck();
            SetDateText();

            timeOfDay.text = "Day";
            sun.transform.eulerAngles = new Vector3(dayAngle, 0f, 0f);
        }
    }

    //public void SetTime(string date, bool evening)
    //{
    //    this.date.text = date;
    //    if (evening)
    //    {
    //        sun.transform.eulerAngles = new Vector3(eveningAngle, 0f, 0f);
    //        this.timeOfDay.text = "Evening";
    //    }
    //    else
    //    {
    //        sun.transform.eulerAngles = new Vector3(dayAngle, 0f, 0f);
    //        this.timeOfDay.text = "Day";
    //    }
    //}

    private void SetDateText()
    {
        //format: Example: 18th September, 1888
        date_Text = day.ToString() + "th " + month + ", " + year.ToString();
        date.text = date_Text;
    }

    private void DateOutOfBoundsCheck()
    {
        //30 days in September, 31 in October, 30 in November 
        //Game starts in September, ends in November. Check for boundaries, don't let 32nd of September show lmaooo
        if (month.Equals("September"))
        {
            if (day >= 31)
            {
                day = 1;        //reset to the first day of the month and push the month forward one
                month = "October";
            }
        }
        else if (month.Equals("October"))
        {
            if (day >= 32)
            {
                day = 1;
                month = "November";
            }
        }
    }

    public string GetDate()
    {
        return date_Text;
    }

    public int GetDay()
    {
        return day;
    }
}
