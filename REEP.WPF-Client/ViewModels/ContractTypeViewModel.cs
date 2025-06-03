using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using REEP.WPF_Client.Models.ContractType.QueryVm.DetailsVm;
using REEP.WPF_Client.Models.ContractType.QueryVm.ListVm;
using REEP.WPF_Client.Services.ApiServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace REEP.WPF_Client.ViewModels
{
    public partial class ContractTypeViewModel : ObservableObject
    {
        [ObservableProperty]
        private ContractTypeListVm _contractTypes;

        [ObservableProperty]
        private ContractTypeLookupDto _selectedItemByContractTypes;

        [ObservableProperty]
        private ContractTypeLookupDto _contractTypeLookupDto;

        [ObservableProperty]
        private ContractTypeDetailsVm _contractType;

        [ObservableProperty]
        private Guid _id;

        [ObservableProperty]
        private bool _isDeleted = false;

        private readonly ContractTypeService _contractTypeService;

        public ContractTypeViewModel(ContractTypeService contractTypeService)
        {
            _contractTypeService = contractTypeService;
            _ = LoadView();
        }

        private async Task LoadView()
        {
            await GetContractTypes();
        }

        [RelayCommand]
        private async Task GetContractTypes()
        {
            ContractTypes = await _contractTypeService.GetContractTypes(_isDeleted);
        }

        [RelayCommand]
        private void GetSelectItemByContractTypes()
        {
            if (SelectedItemByContractTypes is ContractTypeLookupDto)
            {
                try
                {
                    ContractTypeLookupDto = new ContractTypeLookupDto
                    {
                        Type = SelectedItemByContractTypes.Type,
                        IsDeleted = SelectedItemByContractTypes.IsDeleted
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка в выбранного элемента: \n{ex.Message}");
                }
            }
        }

        [RelayCommand]
        private async Task GetContractType()
        {
            _contractType = await _contractTypeService.GetContractType(_id);
        }
    }
}