using ShrackForStudents.Base;
using ShrackForStudents.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShrackForStudents.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : BaseView
	{
		public RegisterPage ()
		{
			InitializeComponent ();            
            //register_headingLabel.Text = AppResources.res_register_headingLabel;            
		}
	}
}