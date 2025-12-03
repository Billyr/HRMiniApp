using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using HRMiniApp.Module.BusinessObjects;
using HRMiniApp.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HRMiniApp.Module.Controllers
{
    public partial class EmployeeApiController : ObjectViewController<ListView, Employee>
    {
        private readonly EmployeeApiService _apiService;
        private SimpleAction ImportEmployeesAction { get; }

        // Parameterless constructor to satisfy XAF0004
        public EmployeeApiController() : this(null) { }

        [ActivatorUtilitiesConstructor]
        public EmployeeApiController(EmployeeApiService apiService)
        {
            _apiService = apiService;

            ImportEmployeesAction = new SimpleAction(this, "ImportEmployees", PredefinedCategory.View)
            {
                Caption = "📥 Import Employees",
                ImageName = "Action_Import",
                TargetViewType = ViewType.ListView,
                SelectionDependencyType = SelectionDependencyType.Independent
            };
            ImportEmployeesAction.Execute += ImportEmployeesAction_Execute;

            //Actions.Add(ImportEmployeesAction);
        }

        private async void ImportEmployeesAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var apiEmployees = await _apiService.GetEmployeesAsync();

            var os = View.ObjectSpace;
            foreach (var apiEmp in apiEmployees.Take(5))
            {
                var existing = os.GetObjects<Employee>()
                    .FirstOrDefault(emp => emp.FirstName == apiEmp.Name.Split(' ').First());

                if (existing == null)
                {
                    var newEmp = os.CreateObject<Employee>();
                    newEmp.FirstName = apiEmp.Name.Split(' ').First();
                    newEmp.LastName = string.Join(" ", apiEmp.Name.Split(' ').Skip(1));
                }
                else
                {
                    //existing. = "Updated from API";
                }
            }

            os.CommitChanges();
            View.ObjectSpace.Refresh();

            //Frame.GetController<MessageController>()?.ShowMessage("✅ Employees imported from API");
            // ✅ Blazor notification
            Application.ShowViewStrategy.ShowMessage(
                "✅ Employees imported from API",
                InformationType.Success,
                2000,
                InformationPosition.Top
            );
        }
    }
}
