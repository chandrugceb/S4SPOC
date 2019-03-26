using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ShrackForStudents.CustomControl;
using ShrackForStudents.Droid.CustomControlRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace ShrackForStudents.Droid.CustomControlRenderer
{
    public class CustomPickerRenderer : PickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
                Control.SetTextColor(global::Android.Graphics.Color.Black);
               // Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "Roboto-Light.ttf");  // font name specified here
                //Control.Typeface = font;
                
                //Control.Text = "--" + ShrackForStudents.Localize.GetString("res_cand_profile_bankAccountDetails_pickerSelect", String.Empty) + "--";
                Control.SetMinimumWidth(6);
                Control.SetPadding(0, 3, 0, 3);
                Control.SetTextSize(Android.Util.ComplexUnitType.Dip, 16);
            }
        }
    }
}