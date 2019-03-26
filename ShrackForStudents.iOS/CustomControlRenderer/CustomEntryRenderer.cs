using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using ShrackForStudents.CustomControl;
using ShrackForStudents.iOS.CustomControlRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace ShrackForStudents.iOS.CustomControlRenderer
{
    public class CustomEntryRenderer: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);           
            
        }
    }
}