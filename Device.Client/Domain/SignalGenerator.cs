using System;
using Device.Client.Domain.Types;

namespace Device.Client.Domain.DataHelper
{
    public static class SignalGenerator
    {
        //NOTE: Modified from here: https://www.codeproject.com/Articles/30180/Simple-Signal-Generator
        public static decimal GetValue(SignalType signalType, decimal time, decimal frequency, decimal amplitude)

        {
            float value = 0f;
            float t = (float)frequency * (float)time;
            switch (signalType)
            { 
                //http://en.wikipedia.org/wiki/Waveform
                case SignalType.Sine: // sin( 2 * pi * t )
                    value = (float)Math.Sin(2f * Math.PI * t);
                    break;
                case SignalType.Square: // sign( sin( 2 * pi * t ) )
                    value = Math.Sign(Math.Sin(2f * Math.PI * t));
                    break;
                case SignalType.Triangle:
                    // 2 * abs( t - 2 * floor( t / 2 ) - 1 ) - 1
                    value = 1f - 4f * (float)Math.Abs
                        (Math.Round(t - 0.25f) - (t - 0.25f));
                    break;
            }

            return (decimal)((float)amplitude * value);
        }
    }
}
