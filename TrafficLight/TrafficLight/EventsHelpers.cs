using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight;
using static TrafficLights.Objects.TrafficL;

internal static class EventsHelpers
{
    public static Action<TrafficLightState> OnChangeState;
}