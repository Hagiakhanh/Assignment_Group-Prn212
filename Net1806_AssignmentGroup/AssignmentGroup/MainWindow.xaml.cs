using AssignmentGroup_Repository.Models;
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
    }
}