using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using TipCalc.Core.ViewModels;

namespace TipCalc.Core
{
    public static class Session
    {
        public static int DetailsCount { get; set; }
        public static DetailsViewModel DetailsViewModel { get; internal set; }
        public static TipViewModel TipViewModel { get; internal set; }
    }
}
