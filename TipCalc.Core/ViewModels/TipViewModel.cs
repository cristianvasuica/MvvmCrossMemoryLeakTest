using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculationService _calculationService;
        private readonly IMvxNavigationService _navigationService;
        public IMvxCommand NavigateCommand { get; set; }

        public TipViewModel(ICalculationService calculationService, IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _calculationService = calculationService;
            NavigateCommand = new MvxCommand(() => _navigationService.Navigate<DetailsViewModel>());
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            SubTotal = 100;
            Generosity = 10;
            Recalcuate();
        }

        private double _subTotal;
        public double SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);

                Recalcuate();
            }
        }

        private int _generosity;
        public int Generosity
        {
            get => _generosity;
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);

                Recalcuate();
            }
        }

        private double _tip;
        public double Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        private void Recalcuate()
        {
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();

            //Code navigate between the screens multiple times; Just to see better the memory increase.
            //if (Session.DetailsCount < 50)
            //{
            //    NavigateCommand.Execute();
            //}
        }
    }
}
