using System;

namespace Roulette
{
    public class RoundEndedEventArgs : EventArgs
    {
        public string Message { get; set; }

        public RoundEndedEventArgs(string message)
        {
            Message = message;
        }
    }
}