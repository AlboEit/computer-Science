﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrafficLights.Objects.TrafficL;

namespace TrafficLight
{
    public class Events
    {
        internal static Action<TrafficLightState> OnChangeState;
    }
}
