﻿using AssignmentGroup_Repository.Models;
using AssignmentGroup_Repository.ModelsView;
using AssignmentGroup_Repository.Repo;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AssignmentGroup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CarDbSetContext _context;
        UnitOfWork _unitOfWork;
        public MainWindow()
        {
            InitializeComponent();
            _context = new CarDbSetContext();
            _unitOfWork = new UnitOfWork(_context);
            LoadData();
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var records = csv.GetRecords<CarCsvModel>().ToList();

                var fuelTypes = records.Select(r => r.Fuel_Type).Distinct().Select(ft => new FuelType { FuelTypeName = ft }).ToList();
                var sellerTypes = records.Select(r => r.Seller_Type).Distinct().Select(st => new SellerType { SellerTypeName = st }).ToList();
                var transmissions = records.Select(r => r.Transmission).Distinct().Select(t => new Transmission { TransmissionType = t }).ToList();
                var owners = records.Select(r => r.Owner).Distinct().Select(o => new Owner { OwnerType = o }).ToList();
                _context.FuelTypes.AddRange(fuelTypes);
                _context.SellerTypes.AddRange(sellerTypes);
                _context.Transmissions.AddRange(transmissions);
                _context.Owners.AddRange(owners);
                _context.SaveChanges();

                var cars = records.Select(r => new Car
                {
                    Year = r.Year,
                    SellingPrice = (decimal)r.Selling_Price,
                    PresentPrice = (decimal)r.Present_Price,
                    KmsDriven = r.Kms_Driven,
                    FuelTypeId = fuelTypes.First(ft => ft.FuelTypeName == r.Fuel_Type).FuelTypeId,
                    SellerTypeId = sellerTypes.First(st => st.SellerTypeName == r.Seller_Type).SellerTypeId,
                    TransmissionId = transmissions.First(t => t.TransmissionType == r.Transmission).TransmissionId,
                    OwnerId = owners.First(o => o.OwnerType == r.Owner).OwnerId
                }).ToList();

                _context.Cars.AddRange(cars);
                _context.SaveChanges();

                dataGridCars.ItemsSource = cars;
                dataGridCars.AutoGenerateColumns = true;
            }
            System.Windows.MessageBox.Show("Import successfully");
        }

        private void LoadData()
        {
            Expression<Func<Car, bool>> fillter = x=> true;
            var ListCar = _unitOfWork.CarRepository.GetAll(fillter,c => c.FuelType, c => c.Owner, c => c.SellerType, c => c.Transmission).ToList();
            var listCarView = ListCar.Select(x => new CarView()
            {
                CarId = x.CarId,
                KmsDriven = x.KmsDriven,
                PresentPrice = x.PresentPrice,
                Year = x.Year,
                FuelTypeName = x.FuelType.FuelTypeName,
                Owner = x.Owner.OwnerType,
                SellerTypeName = x.SellerType.SellerTypeName,
                SellingPrice = x.SellingPrice,
                TransmissionName = x.Transmission.TransmissionType
            }).ToList();
            dataGridCars.ItemsSource = listCarView;
            dataGridCars.AutoGenerateColumns= true;
        }
    }
}