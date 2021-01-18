
/// Copyright (C) 2020 Leevi Liimatainen - All Rights Reserved

namespace KiviApp
{
    /// <summary>
    /// Interface that is being used to make toast message on Android.
    /// </summary>
    public interface IMessage
    {
        void ShowAlert(string message);
    }
}
