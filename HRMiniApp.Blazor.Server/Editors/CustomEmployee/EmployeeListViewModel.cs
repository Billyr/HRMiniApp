using DevExpress.ExpressApp.Blazor.Components.Models;
using HRMiniApp.Blazor.Server.Editors.CustomEmployee;
using HRMiniApp.Blazor.Server.Editors.CustomList;
using HRMiniApp.Module.BusinessObjects;
using Microsoft.AspNetCore.Components;

public class EmployeeListViewModel : ComponentModelBase
{
    public IEnumerable<Employee> Data
    {
        get => GetPropertyValue<IEnumerable<Employee>>();
        set => SetPropertyValue(value);
    }
    public EventCallback<Employee> ItemClick
    {
        get => GetPropertyValue<EventCallback<Employee>>();
        set => SetPropertyValue(value);
    }
    public override Type ComponentType => typeof(EmployeeListView);

}
