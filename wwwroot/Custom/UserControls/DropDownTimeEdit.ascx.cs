using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

public enum TimePickerTimeFormat
{
    TwentyFourHours,
    TwelveHours
}

public enum TimePickerTimeInterval
{
    One,
    Two,
    Five,
    Ten,
    Fifteen,
    Twenty,
    Thirty
}

public enum TimePickerTimeAMPM
{
    AM,
    PM
}

public partial class Custom_UserControls_DropDownTimeEdit : System.Web.UI.UserControl
{
   
    private bool _hasAValue;

    public bool HasAValue
    {
        get
        {
            return _hasAValue;
        }
    }

    public DateTime SelectedTime
    {
        get
        {
            return GenerateDateTime();
        }
        set
        {
            SetDateTime(value);
            _hasAValue = true;
        }
    }

    [
    Bindable(true),
    DefaultValue(""),
    Description("Client javascript name"),
    ]
    public string ClientInstanceName
    {
        get;
        set;
    }

    [Bindable(true),
    DefaultValue(false),
    Description("The field is Required"),
    ]
    public bool IsRequired
    {
        get;
        set;
    }

    [
    Bindable(true),
    Category("Appearance"),
    DefaultValue(TimePickerTimeFormat.TwelveHours),
    Description("Time Format"),
    ]
    public TimePickerTimeFormat Format
    {
        get;
        set;
    }

    [
    Bindable(true),
    Category("Appearance"),
    DefaultValue(TimePickerTimeInterval.One),
    Description("Minute Interval"),
    ]
    public TimePickerTimeInterval Interval
    {
        get;
        set;
    }

    [
   Bindable(true),
   Category("Appearance"),
   DefaultValue(0),
   Description("Hour Width"),
   ]
    public int HourWidth { get; set; }

    [
   Bindable(true),
   Category("Appearance"),
   DefaultValue(0),
   Description("Minute Width"),
   ]
    public int MinuteWidth { get; set; }

    [
  Bindable(true),
  Category("Appearance"),
  DefaultValue(0),
  Description("AM PM Width"),
  ]
    public int AMPMWidth { get; set; }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            drpAmPm.Items.AddRange(GenerateAmPm());
            drpHours.Items.AddRange(GenerateHours());
            drpMinutes.Items.AddRange(GenerateMinutes());
            string clientName = !string.IsNullOrEmpty(ClientInstanceName) ? ClientInstanceName : ClientID;
            drpAmPm.ClientInstanceName = string.Format("{0}_drpAmPm", clientName);
            drpHours.ClientInstanceName = string.Format("{0}_drpHours", clientName);
            drpMinutes.ClientInstanceName = string.Format("{0}_drpMinutes", clientName);
            drpAmPm.ValidationSettings.RequiredField.IsRequired = IsRequired;
            drpAmPm.ValidationSettings.RequiredField.ErrorText = "Please select AM/PM";
            drpHours.ValidationSettings.RequiredField.IsRequired = IsRequired;
            drpHours.ValidationSettings.RequiredField.ErrorText = "Please select hour";
            drpMinutes.ValidationSettings.RequiredField.IsRequired = IsRequired;
            drpMinutes.ValidationSettings.RequiredField.ErrorText = "Please select minute";
            if (AMPMWidth > 0)
                drpAmPm.Width = AMPMWidth;
            if (MinuteWidth > 0)
                drpMinutes.Width = MinuteWidth;
            if (HourWidth > 0)
                drpHours.Width = HourWidth;
            if (Format == TimePickerTimeFormat.TwelveHours)
            {
                ltScript.Text = @"<script>window['" + clientName + @"'] = {
    GetDate: function (inDate)
    {
        var hours = " + drpHours.ClientInstanceName + ".GetValue() !== null ? " + drpHours.ClientInstanceName + @".GetValue() : 0,
            minutes = " + drpMinutes.ClientInstanceName + ".GetValue() !== null ? " + drpMinutes.ClientInstanceName + @".GetValue() : 0
        amPm = " + drpAmPm.ClientInstanceName + ".GetValue() !== null ? " + drpAmPm.ClientInstanceName + @".GetValue() : '-';
        if (amPm === 'PM')
        {
            inDate.setHours(hours + 11);
            inDate.setMinutes(minutes);
        }
        else
        {
            inDate.setHours(hours);
            inDate.setMinutes(minutes);
        }
        return inDate;
    },
    GetValue: function ()
    {
        if(" + drpHours.ClientInstanceName + @".GetValue() === null)
            return null;
        if(" + drpMinutes.ClientInstanceName + @".GetValue() === null)
            return null;
        if(" + drpAmPm.ClientInstanceName + @".GetValue() === null)
            return null;
        var hours = " + drpHours.ClientInstanceName + ".GetValue() !== null ? " + drpHours.ClientInstanceName + @".GetValue() : 0,
            minutes = " + drpMinutes.ClientInstanceName + ".GetValue() !== null ? " + drpMinutes.ClientInstanceName + @".GetValue() : 0
        amPm = " + drpAmPm.ClientInstanceName + ".GetValue() !== null ? " + drpAmPm.ClientInstanceName + @".GetValue() : '-';
        var inDate = new Date();
        if (amPm === 'PM')
        {
            inDate.setHours(hours + 11);
            inDate.setMinutes(minutes);
        }
        else
        {
            inDate.setHours(hours);
            inDate.setMinutes(minutes);
        }
        return inDate;
    }
};</script>";
            }
            else
            {
                ltScript.Text = @"<script>window['" + clientName + @"'] = {
    GetDate: function (inDate)
    {
        var hours = " + drpHours.ClientInstanceName + ".GetValue() !== null ? " + drpHours.ClientInstanceName + @".GetValue() : 0,
            minutes = " + drpMinutes.ClientInstanceName + ".GetValue() !== null ? " + drpMinutes.ClientInstanceName + @".GetValue() : 0;
        inDate.setHours(hours);
        inDate.setMinutes(minutes);
        return inDate;
    },
    GetValue: function ()
    {
        if(" + drpHours.ClientInstanceName + @".GetValue() === null)
            return null;
        if(" + drpMinutes.ClientInstanceName + @".GetValue() === null)
            return null;
        var hours = " + drpHours.ClientInstanceName + ".GetValue() !== null ? " + drpHours.ClientInstanceName + @".GetValue() : 0,
            minutes = " + drpMinutes.ClientInstanceName + ".GetValue() !== null ? " + drpMinutes.ClientInstanceName + @".GetValue() : 0;
         var inDate = new Date();
        inDate.setHours(hours);
        inDate.setMinutes(minutes);
        return inDate;
    }
};</script>";
            }
        }
    }

    private List<ListEditItem> GenerateHours()
    {
        List<ListEditItem> items = new List<ListEditItem>();

        switch (Format)
        {
            case TimePickerTimeFormat.TwentyFourHours:
                for (int i = 0; i < 24; i++)
                {
                    items.Add(new ListEditItem(String.Format("{0:00}", i), i));
                }
                break;
            case TimePickerTimeFormat.TwelveHours:
                for (int i = 1; i < 13; i++)
                {
                    items.Add(new ListEditItem(String.Format("{0:00}", i), i - 1));
                }
                break;
        }
        return items;
    }

    private List<ListEditItem> GenerateAmPm()
    {
        List<ListEditItem> items = new List<ListEditItem>();
        if (Format == TimePickerTimeFormat.TwelveHours)
        {
            items.Add(new ListEditItem(TimePickerTimeAMPM.AM.ToString(), TimePickerTimeAMPM.AM.ToString()));
            items.Add(new ListEditItem(TimePickerTimeAMPM.PM.ToString(), TimePickerTimeAMPM.PM.ToString()));
            drpAmPm.Visible = true;
        }
        else
        {
            drpAmPm.Visible = false;
        }
        return items;
    }

    private List<ListEditItem> GenerateMinutes()
    {
        List<ListEditItem> items = new List<ListEditItem>();
        int interval = 0;
        switch (Interval)
        {
            case TimePickerTimeInterval.One:
                interval = 1;
                break;
            case TimePickerTimeInterval.Two:
                interval = 2;
                break;
            case TimePickerTimeInterval.Five:
                interval = 5;
                break;
            case TimePickerTimeInterval.Ten:
                interval = 10;
                break;
            case TimePickerTimeInterval.Fifteen:
                interval = 15;
                break;
            case TimePickerTimeInterval.Thirty:
                interval = 30;
                break;
        }
        if (interval != 0)
        {
            for (int i = 0; i < 60; i += interval)
            {
                items.Add(new ListEditItem(String.Format("{0:00}", i), i));
            }
        }
        return items;
    }

    private DateTime GenerateDateTime()
    {
        DateTime today = DateTime.Today;
        int hours = 0;
        int minutes = 0;
        switch (Format)
        {
            case TimePickerTimeFormat.TwelveHours:
                hours = ParseNumber(drpHours.Value.ToString());
                minutes = ParseNumber(drpMinutes.Value.ToString());
                TimePickerTimeAMPM amPm = ParseAMPM(drpAmPm.Value.ToString());
                return new DateTime(today.Year, today.Month, today.Day, ParseTwentyFourHourFormatFromTime(hours, amPm), minutes, 0);
            case TimePickerTimeFormat.TwentyFourHours:
                hours = ParseNumber(drpHours.Value.ToString());
                minutes = ParseNumber(drpMinutes.Value.ToString());
                return new DateTime(today.Year, today.Month, today.Day, hours, minutes, 0);
        }
        return today;
    }

    private void SetDateTime(DateTime time)
    {
        int hours = 0;
        int minutes = 0;
        string amPM = String.Empty;
        int round = 0;

        switch (Interval)
        {
            case TimePickerTimeInterval.One:
                round = 0;
                break;
            case TimePickerTimeInterval.Two:
                round = 2;
                break;
            case TimePickerTimeInterval.Five:
                round = 5;
                break;
            case TimePickerTimeInterval.Ten:
                round = 10;
                break;
            case TimePickerTimeInterval.Fifteen:
                round = 15;
                break;
            case TimePickerTimeInterval.Thirty:
                round = 30;
                break;
        }
        minutes = RoundOff(time.Minute, round);

        switch (Format)
        {
            case TimePickerTimeFormat.TwelveHours:
                if (time.Hour > 12)
                {
                    hours = (time.Hour - 12);
                    amPM = "PM";
                }
                else
                {
                    hours = time.Hour;
                    amPM = "AM";
                }
                break;
            case TimePickerTimeFormat.TwentyFourHours:
                hours = time.Hour;
                break;
        }
        SetControlDate(String.Format("{0:00}", hours), String.Format("{0:00}", minutes), amPM);
    }

    private void SetControlDate(string hours, string minutes, string amPm)
    {
        drpHours.Value = hours;
        drpMinutes.Value = minutes;
        if (Format == TimePickerTimeFormat.TwelveHours)
        {
            drpAmPm.Visible = true;
            drpAmPm.Value = amPm;
        }
        else
        {
            drpAmPm.Visible = false;
        }
    }

    private int ParseNumber(ListItem listItem)
    {
        return ParseNumber(listItem.Value);
    }

    private int ParseNumber(string text)
    {
        int value = 0;
        if (int.TryParse(text, out value))
        {
            return value;
        }
        return 0;
    }

    private TimePickerTimeAMPM ParseAMPM(ListItem item)
    {
        return ParseAMPM(item.Value);
    }

    private TimePickerTimeAMPM ParseAMPM(string text)
    {
        switch (text.ToUpper())
        {
            case "AM":
                return TimePickerTimeAMPM.AM;
            case "PM":
                return TimePickerTimeAMPM.PM;
        }
        throw new Exception("Could not parse AM/PM");
    }

    private int ParseTwentyFourHourFormatFromTime(int hour, TimePickerTimeAMPM amPm)
    {
        switch (amPm)
        {
            case TimePickerTimeAMPM.AM:
                return hour;
            case TimePickerTimeAMPM.PM:
                return hour + 12;
        }
        return 0;
    }

    private int RoundOff(int i, int roundTo)
    {
        if (roundTo != 0)
        {
            return ((int)Math.Round(i / (decimal)roundTo)) * roundTo;
        }
        else
        {
            return i;
        }
    }
}