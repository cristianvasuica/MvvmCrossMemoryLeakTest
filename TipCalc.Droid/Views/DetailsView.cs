using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using TipCalc.Core.ViewModels;

namespace TipCalc.UI.Droid.Views
{
    [Activity(Label = "Details")]
    public class DetailsView : MvxActivity<DetailsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DetailsView);
        }

        protected override void OnDestroy()
        {
            //this is never called. Why?
            base.OnDestroy();
        }
        
    }
}