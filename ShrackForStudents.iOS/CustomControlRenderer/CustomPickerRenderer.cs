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

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace ShrackForStudents.iOS.CustomControlRenderer
{
    public class CustomPickerRenderer: PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            Control.BorderStyle = UITextBorderStyle.None;
            
            //Control.Text = "--" + JiTr.Localize.GetString("res_cand_profile_bankAccountDetails_pickerSelect", String.Empty) + "--";
        }
    }
}