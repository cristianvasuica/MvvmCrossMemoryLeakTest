using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;

namespace TipCalc.Core.ViewModels
{
    public class DetailsViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public IMvxCommand CloseCommand { get; set; }

        public IMvxCommand CollectCommand { get; set; }

        public DetailsViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            CloseCommand = new MvxCommand(() => Navigate());
            CollectCommand = new MvxCommand(() => GC.Collect());
            Session.DetailsViewModel = this;
        }

        private void Navigate()
        {
            _navigationService.Navigate(Session.TipViewModel);
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            //Session.DetailsCount += 1;
            //if (Session.DetailsCount < 100)
            //{
            //    CloseCommand.Execute();
            //}
        }
    }
}
