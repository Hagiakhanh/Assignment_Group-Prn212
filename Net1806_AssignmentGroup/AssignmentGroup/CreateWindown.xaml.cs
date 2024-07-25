using AssignmentGroup_Repository.Models;
using AssignmentGroup_Repository.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AssignmentGroup
{
    /// <summary>
    /// Interaction logic for CreateWindown.xaml
    /// </summary>
    public partial class CreateWindown : Window
    {
        CarDbSetContext _context;
        UnitOfWork _unitOfWork;
        public CreateWindown()
        {
            InitializeComponent();
            _context = new CarDbSetContext();
            _unitOfWork = new UnitOfWork(_context);
            LoadDataCombobox();
        }
        public bool ValidationInput()
        {
            int Year = -1;
            decimal SellingPrice = -1;
            decimal PresentPrice = -1;
            int KmsDriven = -1;

            int.TryParse(txtYear.Text, out Year);
            decimal.TryParse(txtSellingPrice.Text, out SellingPrice);
            decimal.TryParse(txtPresentPrice.Text, out PresentPrice);
            int.TryParse(txtKmDriven.Text, out KmsDriven);

            if(Year <= 0)
            {
                MessageBox.Show("Please enter valid year");
                return false;
            }

            if (SellingPrice <= 0)
            {
                MessageBox.Show("Please enter valid selling price");
                return false;
            }

            if (PresentPrice <= 0)
            {
                MessageBox.Show("Please enter valid present price");
                return false;
            }

            if (KmsDriven <= 0)
            {
                MessageBox.Show("Please enter valid kms driven");
                return false;
            }

            if (cbbFuelType.SelectedValue == null)
            {
                MessageBox.Show("Please choose fuel type");
                return false;
            }

            if (cbbSellerType.SelectedValue == null)
            {
                MessageBox.Show("Please choose seller type");
                return false;
            }

            if (cbbTransmission.SelectedValue == null)
            {
                MessageBox.Show("Please choose transmission");
                return false;
            }

            if (cbbOwner.SelectedValue == null)
            {
                MessageBox.Show("Please choose owner");
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationInput())
            {
                Car objectCar = new Car()
                {
                    Year = int.Parse(txtYear.Text),
                    SellingPrice = decimal.Parse(txtSellingPrice.Text),
                    PresentPrice = decimal.Parse(txtPresentPrice.Text),
                    KmsDriven = int.Parse(txtKmDriven.Text),
                    FuelTypeId = int.Parse(cbbFuelType.SelectedValue.ToString()),
                    SellerTypeId = int.Parse(cbbSellerType.SelectedValue.ToString()),
                    TransmissionId = int.Parse(cbbTransmission.SelectedValue.ToString()),
                    OwnerId = int.Parse(cbbOwner.SelectedValue.ToString())
                };
                _unitOfWork.CarRepository.Insert(objectCar);
                _unitOfWork.Save();
                this.Close();
            }
        }
        public void LoadDataCombobox()
        {
            var listFuelType = _unitOfWork.FuelTypeRepository.GetAll().ToList();
            var listSellerType = _unitOfWork.SellerTypeRepository.GetAll().ToList();
            var listTransmisstion = _unitOfWork.TransmissionRepository.GetAll().ToList();
            var listOwner = _unitOfWork.OwnerRepository.GetAll().ToList();

            cbbFuelType.ItemsSource = listFuelType;
            cbbFuelType.DisplayMemberPath = nameof(FuelType.FuelTypeName);
            cbbFuelType.SelectedValuePath = nameof(FuelType.FuelTypeId);

            cbbSellerType.ItemsSource = listSellerType;
            cbbSellerType.DisplayMemberPath = nameof(SellerType.SellerTypeName);
            cbbSellerType.SelectedValuePath = nameof(SellerType.SellerTypeId);

            cbbTransmission.ItemsSource = listTransmisstion;
            cbbTransmission.DisplayMemberPath = nameof(Transmission.TransmissionType);
            cbbTransmission.SelectedValuePath = nameof(Transmission.TransmissionId);

            cbbOwner.ItemsSource = listOwner;
            cbbOwner.DisplayMemberPath = nameof(AssignmentGroup_Repository.Models.Owner.OwnerType);
            cbbOwner.SelectedValuePath = nameof(AssignmentGroup_Repository.Models.Owner.OwnerId);
        }
    }
}
