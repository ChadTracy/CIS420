using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevExpress.Web.Demos
{
    public partial class ImageSliderController : DemoController
    {
        [HttpGet]
        public ActionResult SlideShow()
        {
            ViewData["Options"] = new ImageSliderSlideShowDemoOptions();
            return DemoView("SlideShow");
        }
        [HttpPost]
        public ActionResult SlideShow(ImageSliderSlideShowDemoOptions options)
        {
            ViewData["Options"] = options;
            return DemoView("SlideShow");
        }
    }
}