using QuantityMeasurementControllers.Controller;
using QuantityMeasurementControllers.Menu;
using QuantityMeasurementServices.Interfaces;
using QuantityMeasurementServices.Services;
using QuantityMeasurementRepository.Cache;
using QuantityMeasurementRepository.Database;
using QuantityMeasurementRepository.Interfaces;

IQuantityMeasurementRepository repository = new QuantityMeasurementDatabaseRepository();
IQuantityMeasurementService service = new QuantityMeasurementService(repository);
Menu menu = new Menu(service);

menu.Show();