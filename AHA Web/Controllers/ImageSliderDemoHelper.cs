using System.Collections.Generic;
using System.Web.Mvc;

namespace DevExpress.Web.Demos
{
    public static class ImageSliderDemoHelper
    {
        public static List<SelectListItem> GetPredefinedScenarios(string selectedScenario)
        {
            List<SelectListItem> predefinedScenarios = new List<SelectListItem>() {
                new SelectListItem() { Text = "Default", Value = "Default" },
                new SelectListItem() { Text = "Fill and Crop, Dots", Value = "FillAndCropDots" },
                new SelectListItem() { Text = "Vertical Scrolling", Value = "VerticalScrolling" }
            };
            if (!string.IsNullOrEmpty(selectedScenario))
                predefinedScenarios.Find(item => item.Value == selectedScenario).Selected = true;
            return predefinedScenarios;
        }
        public static List<SelectListItem> GetSlideShowIntervals()
        {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = "1000", Value = "1000" },
                new SelectListItem() { Text = "2000", Value = "2000" },
                new SelectListItem() { Text = "3000", Value = "3000" },
                new SelectListItem() { Text = "5000", Value = "5000", Selected = true }
            };
        }
        public static List<SelectListItem> GetSourceFolders()
        {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = "Landscapes", Value = "~/Content/Images/landscapes", Selected = true },
                new SelectListItem() { Text = "People", Value = "~/Content/Images/people" },
                new SelectListItem() { Text = "Photo Gallery", Value = "~/Content/Images/photo_gallery" }
            };
        }
        public static List<SelectListItem> GetCategories()
        {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = "All", Value = null, Selected = true },
                new SelectListItem() { Text = "Vegetables", Value = "1" },
                new SelectListItem() { Text = "Fruits", Value = "2" },
                new SelectListItem() { Text = "Mushrooms", Value = "3" },
                new SelectListItem() { Text = "Cereal", Value = "4" }
            };
        }
        public static List<SelectListItem> GetVisibleItemsCount()
        {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = "3", Value = "3" },
                new SelectListItem() { Text = "5", Value = "5", Selected = true }
            };
        }
    }
}
