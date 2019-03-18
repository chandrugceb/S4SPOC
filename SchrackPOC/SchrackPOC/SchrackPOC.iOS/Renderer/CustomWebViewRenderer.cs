using System;
using SchrackPOC.Controls;
using SchrackPOC.iOS.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ObjCRuntime;
using Foundation;
using UIKit;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))] 
namespace SchrackPOC.iOS.Renderer
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        //protected override void OnElementChanged(VisualElementChangedEventArgs e)
        //{
        //    e.
        //    base.OnElementChanged(e);
        //    if (Control != null)
        //    {
        //        var nativeTextField = (UITextField)Control;
        //        nativeTextField.EditingDidBegin += (object sender, EventArgs eIos) =>
        //        {
        //            nativeTextField.PerformSelector(new Selector("selectAll"), null, 0.0f);
        //        };
        //    }
        //}



        public override bool CanPerform(Selector action, NSObject withSender)   
                {
            //Selector markerAction = new Selector("");

            //Selector commentAction = new Selector("");

            //Selector bookmarkAction = new Selector("");

            //UIMenuItem markerItem = new UIMenuItem("Marker", markerAction);

            //UIMenuItem commentItem = new UIMenuItem("Comment", commentAction);

            //UIMenuItem bookmarkItem = new UIMenuItem("Bookmark", bookmarkAction);

            NSOperationQueue.MainQueue.AddOperation(() =>   
            {   
                UIMenuController.SharedMenuController.SetMenuVisible(false, false);  
                //UIMenuController.SharedMenuController.MenuItems = new UIMenuItem[] { markerItem, commentItem, bookmarkItem };

            });



            return base.CanPerform(action, withSender);   
                }   
    }
}
