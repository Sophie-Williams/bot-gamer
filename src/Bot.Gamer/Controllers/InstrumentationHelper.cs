﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bot.Gamer.Controllers
{
    public class InstrumentationHelper
    {
        public static BotBuilder.Instrumentation.Interfaces.IBotFrameworkInstrumentation DefaultInstrumentation =>
            BotBuilder.Instrumentation.DependencyResolver.Current.DefaultInstrumentationWithCognitiveServices;
    }
}