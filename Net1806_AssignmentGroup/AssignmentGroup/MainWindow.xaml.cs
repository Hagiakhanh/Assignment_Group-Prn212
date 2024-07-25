using AssignmentGroup_Repository.Models;
using AssignmentGroup_Repository.ModelsView;
using AssignmentGroup_Repository.Repo;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
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
        private List<int> selectedFuelTypesId;
        private List<int> selectedOwnerId;
        private List<int> selectedSellerId;
        private List<int> selectedTransmissionId;
        private List<int> selectedYear;
        public MainWindow()
        {
            InitializeComponent();
            _context = new CarDbSetContext();
            _unitOfWork = new UnitOfWork(_context);
            selectedFuelTypesId = new List<int>();
            selectedOwnerId = new List<int>();
            selectedSellerId = new List<int>();
            selectedTransmissionId = new List<int>();
            selectedYear = new List<int>();
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

                _unitOfWork.CarRepository.RemoveRange();
                _unitOfWork.FuelTypeRepository.RemoveRange();
                _unitOfWork.OwnerRepository.RemoveRange();
                _unitOfWork.SellerTypeRepository.RemoveRange();
                _unitOfWork.TransmissionRepository.RemoveRange();

                var fuelTypes = records.Select(r => r.Fuel_Type).Distinct().Select(ft => new FuelType { FuelTypeName = ft }).ToList();
                var sellerTypes = records.Select(r => r.Seller_Type).Distinct().Select(st => new SellerType { SellerTypeName = st }).ToList();
                var transmissions = records.Select(r => r.Transmission).Distinct().Select(t => new Transmission { TransmissionType = t }).ToList();
                var owners = records.Select(r => r.Owner).Distinct().Select(o => new Owner { OwnerType = o }).ToList();

                _unitOfWork.FuelTypeRepository.AddRange(fuelTypes);
                _unitOfWork.SellerTypeRepository.AddRange(sellerTypes);
                _unitOfWork.TransmissionRepository.AddRange(transmissions);
                _unitOfWork.OwnerRepository.AddRange(owners);

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

                _unitOfWork.CarRepository.AddRange(cars);
            }
            System.Windows.MessageBox.Show("Import successfully");
        }
        private void CheckBox_CheckedFuel(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as System.Windows.Controls.CheckBox;
            if (checkBox != null && checkBox.Content != null)
            {
                var FuelTypeId = _unitOfWork.FuelTypeRepository.GetAll().Where(x => x.FuelTypeName.Equals(checkBox.Content.ToString())).Select(x => x.FuelTypeId).FirstOrDefault();
                selectedFuelTypesId.Add(FuelTypeId);
            }
        }

        private void CheckBox_UncheckedFuel(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as System.Windows.Controls.CheckBox;
            if (checkBox != null && checkBox.Content != null)
            {
                var FuelTypeId = _unitOfWork.FuelTypeRepository.GetAll().Where(x => x.FuelTypeName.Equals(checkBox.Content.ToString())).Select(x => x.FuelTypeId).FirstOrDefault();
                selectedFuelTypesId.Remove(FuelTypeId);
            }
        }

        private void CheckBox_CheckedOwner(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as System.Windows.Controls.CheckBox;
            if (checkBox != null && checkBox.Content != null)
            {
                var OwnerId = _unitOfWork.OwnerRepository.GetAll().Where(x => x.OwnerType.Equals(checkBox.Content.ToString())).Select(x => x.OwnerId).FirstOrDefault();
                selectedOwnerId.Add(OwnerId);
            }
        }

        private void CheckBox_UncheckedOwner(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as System.Windows.Controls.CheckBox;
            if (checkBox != null && checkBox.Content != null)
            {
                var OwnerId = _unitOfWork.OwnerRepository.GetAll().Where(x => x.OwnerType.Equals(checkBox.Content.ToString())).Select(x => x.OwnerId).FirstOrDefault();
                selectedOwnerId.Remove(OwnerId);
            }
        }
        private void CheckBox_CheckedTransmission(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as System.Windows.Controls.CheckBox;
            if (checkBox != null && checkBox.Content != null)
            {
                var TransmissionId = _unitOfWork.TransmissionRepository.GetAll().Where(x => x.TransmissionType.Equals(checkBox.Content.ToString())).Select(x => x.TransmissionId).FirstOrDefault();
                selectedTransmissionId.Add(TransmissionId);
            }
        }

        private void CheckBox_UncheckedTransmission(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as System.Windows.Controls.CheckBox;
            if (checkBox != null && checkBox.Content != null)
            {
                var TransmissionId = _unitOfWork.TransmissionRepository.GetAll().Where(x => x.TransmissionType.Equals(checkBox.Content.ToString())).Select(x => x.TransmissionId).FirstOrDefault();
                selectedTransmissionId.Remove(TransmissionId);
            }
        }
        private void CheckBox_CheckedSeller(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as System.Windows.Controls.CheckBox;
            if (checkBox != null && checkBox.Content != null)
            {
                var SellerId = _unitOfWork.SellerTypeRepository.GetAll().Where(x => x.SellerTypeName.Equals(checkBox.Content.ToString())).Select(x => x.SellerTypeId).FirstOrDefault();
                selectedSellerId.Add(SellerId);
            }
        }

        private void CheckBox_UncheckedSeller(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as System.Windows.Controls.CheckBox;
            if (checkBox != null && checkBox.Content != null)
            {
                var SellerId = _unitOfWork.SellerTypeRepository.GetAll().Where(x => x.SellerTypeName.Equals(checkBox.Content.ToString())).Select(x => x.SellerTypeId).FirstOrDefault();
                selectedSellerId.Remove(SellerId);
            }
        }

        private void CheckBox_CheckedYear(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as System.Windows.Controls.CheckBox;
            if (checkBox != null && checkBox.Content != null)
            {
                var Year = int.Parse(checkBox.Content.ToString());
                selectedYear.Add(Year);
            }
        }

        private void CheckBox_UncheckedYear(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as System.Windows.Controls.CheckBox;
            if (checkBox != null && checkBox.Content != null)
            {
                var Year = int.Parse(checkBox.Content.ToString());
                selectedYear.Remove(Year);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ccbCheckBoxFuelName.SelectedItem = null;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                var TypeRangeContent = ccbTypeRange.SelectedItem as string;
                decimal min, max;
                decimal.TryParse(txt_minRange.Text, out min);
                decimal.TryParse(txt_maxRange.Text, out max);
                if (selectedFuelTypesId.Count > 0 || selectedOwnerId.Count > 0 || selectedSellerId.Count > 0 || selectedTransmissionId.Count > 0 || selectedYear.Count > 0 ||
                    min != 0 || max != 0 || ccbTypeRange.SelectedIndex != 0 || ccbSort.SelectedIndex != 0)
                {
                    Expression<Func<Car, bool>> filter = x =>
                    (selectedFuelTypesId.Count == 0 || selectedFuelTypesId.Contains((int)x.FuelTypeId)) &&
                    (selectedOwnerId.Count == 0 || selectedOwnerId.Contains((int)x.OwnerId)) &&
                    (selectedSellerId.Count == 0 || selectedSellerId.Contains((int)x.SellerTypeId)) &&
                    (selectedTransmissionId.Count == 0 || selectedTransmissionId.Contains((int)x.TransmissionId)) &&
                    (selectedYear.Count == 0 || selectedYear.Contains((int)x.Year));
                    var ListCar = _unitOfWork.CarRepository.GetAll(filter, c => c.FuelType, c => c.Owner, c => c.SellerType, c => c.Transmission).ToList();
                    if (min != 0)
                    {
                        ListCar = ListCar.Where(x => decimal.Parse(x.GetType().GetProperty(TypeRangeContent).GetValue(x)?.ToString()) >= min).ToList();
                    }
                    if (max != 0)
                    {
                        ListCar = ListCar.Where(x => decimal.Parse(x.GetType().GetProperty(TypeRangeContent).GetValue(x)?.ToString()) <= max).ToList();
                    }
                    if (ccbSort.SelectedIndex == 0)
                    {
                        ListCar = ListCar.OrderBy(x => x.GetType().GetProperty(TypeRangeContent).GetValue(x)).ToList();

                    }
                    else
                    {
                        ListCar = ListCar.OrderByDescending(x => x.GetType().GetProperty(TypeRangeContent).GetValue(x)).ToList();
                    }
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
                }
                else
                {
                    LoadData();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Error type when input range box");
                LoadData();
            }

        }

        private void LoadData()
        {
            var ListCar = _unitOfWork.CarRepository.GetAll(null, c => c.FuelType, c => c.Owner, c => c.SellerType, c => c.Transmission).ToList();
            if (ListCar.Count > 0)
            {
                List<string> TypeRangeContent = new List<string> {
                "CarId", "Year", "SellingPrice", "PresentPrice", "KmsDriven"
                };
                List<string> Sort = new List<string> {
                "A->Z", "Z->A"
                };
                var FuelTypeNames = _unitOfWork.FuelTypeRepository.GetAll().Select(x => x.FuelTypeName).ToList();
                var Owner = _unitOfWork.OwnerRepository.GetAll().Select(x => x.OwnerType).ToList();
                var TransmissionTypeNames = _unitOfWork.TransmissionRepository.GetAll().Select(x => x.TransmissionType).ToList();
                var SellerTypeNames = _unitOfWork.SellerTypeRepository.GetAll().Select(x => x.SellerTypeName).ToList();
                var year = _unitOfWork.CarRepository.GetAll().GroupBy(x => x.Year).OrderBy(x => x.Key).Select(x => x.Key).ToList();
                ccbCheckBoxFuelName.ItemsSource = FuelTypeNames;
                ccbCheckBoxOwner.ItemsSource = Owner;
                ccbCheckBoxSellerType.ItemsSource = SellerTypeNames;
                ccbCheckBoxTransmission.ItemsSource = TransmissionTypeNames;
                ccbCheckBoYear.ItemsSource = year;
                ccbTypeRange.ItemsSource = TypeRangeContent;
                ccbTypeRange.SelectedItem = TypeRangeContent[0];
                ccbSort.ItemsSource = Sort;
                ccbSort.SelectedItem = Sort[0];

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
                dataGridCars.AutoGenerateColumns = true;
            }
        }

        private bool ValidateInput()
        {
            string patten = @"^(\d+(\.\d{1,2})?)?$";
            if (!Regex.IsMatch(txt_minRange.Text, patten))
            {
                return false;
            }
            if (!Regex.IsMatch(txt_maxRange.Text, patten))
            {
                return false;
            }
            float min, max;
            float.TryParse(txt_minRange.Text, out min);
            float.TryParse(txt_maxRange.Text, out max);

            if (min > max)
            {
                return false;
            }
            return true;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            selectedFuelTypesId = new List<int>();
            selectedOwnerId = new List<int>();
            selectedSellerId = new List<int>();
            selectedTransmissionId = new List<int>();
            selectedYear = new List<int>();
            txt_minRange.Text = "";
            txt_maxRange.Text = "";
            LoadData();

        }
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            Expression<Func<Car, bool>> filter = x => true;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.csv";
            saveFileDialog.Title = "Save an Excel File";
            saveFileDialog.FileName = "Cars.csv";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                try
                {

                    using (var writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine("Car_Name,Year,Selling_Price,Present_Price,Kms_Driven,Fuel_Type,Seller_Type,Transmission");
                        List<Car> cars = _unitOfWork.CarRepository.GetAll(filter, c => c.FuelType, c => c.Owner, c => c.SellerType, c => c.Transmission).ToList();
                        foreach (var car in cars)
                        {
                            writer.WriteLine($"{car.CarId},{car.Year},{car.SellingPrice},{car.PresentPrice},{car.KmsDriven},{car.FuelType.FuelTypeName},{car.SellerType.SellerTypeName},{car.Transmission.TransmissionType}");
                        }
                    }
                }

                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }

                System.Windows.MessageBox.Show("Data exported successfully to " + filePath);
            }


        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateWindown createWindown = new CreateWindown();
            createWindown.ShowDialog();
            LoadData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var itemSelected = dataGridCars.SelectedItem as CarView;
            if (itemSelected != null)
            {
                int itemSelectedId = itemSelected.CarId;
                UpdateWindow updateWindow = new UpdateWindow(itemSelectedId);
                updateWindow.ShowDialog();
                LoadData();

            }
            else
            {
                System.Windows.MessageBox.Show("Please choose item to update");
            }
        }
    }
}