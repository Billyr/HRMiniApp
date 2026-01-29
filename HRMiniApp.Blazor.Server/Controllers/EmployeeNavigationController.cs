using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp;
using Microsoft.AspNetCore.Components;

public class EmployeeNavigationController : WindowController
{
    public EmployeeNavigationController()
    {
        var action = new SimpleAction(this, "EmployeesPage", "Navigation")
        {
            Caption = "Employees Page"
        };
        action.Execute += (s, e) =>
        {
            var nav = Application.ServiceProvider
                .GetRequiredService<NavigationManager>();

            nav.NavigateTo("/employees");
        };
    }
}
