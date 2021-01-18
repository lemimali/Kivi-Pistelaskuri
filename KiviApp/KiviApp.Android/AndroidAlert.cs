using Android.App;
using Android.Views;
using Android.Widget;
using KiviApp.Droid;

/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

[assembly: Xamarin.Forms.Dependency(typeof(AndroidAlert))]
namespace KiviApp.Droid
{
    /// <summary>
    /// Makes a toast to inform user about his/her actions.
    /// </summary>
    public class AndroidAlert : IMessage
    {
        public void ShowAlert(string message)
        {
            Toast toast = Toast.MakeText(Application.Context, message, ToastLength.Long);
            toast.SetGravity(GravityFlags.Center, 0, 0);
            toast.Show();
        }
    }
}