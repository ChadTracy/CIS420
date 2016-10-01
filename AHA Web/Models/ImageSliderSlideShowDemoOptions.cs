using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevExpress.Web.Demos
{
    public class ImageSliderSlideShowDemoOptions
    {
        public ImageSliderSlideShowDemoOptions()
        {
            AutoPlay = true;
            Interval = 5000;
            PlayPauseButtonVisibility = ElementVisibilityMode.Faded;
            StopPlayingWhenPaging = false;
            PausePlayingWhenMouseOver = false;
        }

        public bool AutoPlay { get; set; }
        public int Interval { get; set; }
        public ElementVisibilityMode PlayPauseButtonVisibility { get; set; }
        public bool StopPlayingWhenPaging { get; set; }
        public bool PausePlayingWhenMouseOver { get; set; }
    }
}