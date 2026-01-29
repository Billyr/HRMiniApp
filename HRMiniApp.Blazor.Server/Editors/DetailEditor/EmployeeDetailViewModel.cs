using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Components.Models;
using HRMiniApp.Blazor.Server.Editors.DetailEditor;
using HRMiniApp.Module.BusinessObjects;
using Microsoft.AspNetCore.Components;
using System;

public class EmployeeDetailViewModel : ComponentModelBase
{
    //public View View { get; set; }

    public Employee Employee
    {
        get => GetPropertyValue<Employee>();
        set => SetPropertyValue(value);
    }

    public IEnumerable<Department> Departments
    {
        get => GetPropertyValue<IEnumerable<Department>>();
        set => SetPropertyValue(value);
    }

    public bool IsNew
    {
        get => GetPropertyValue<bool>();
        set => SetPropertyValue(value);
    }

    public EventCallback SaveRequested
    {
        get => GetPropertyValue<EventCallback>();
        set => SetPropertyValue(value);
    }

    public EventCallback CancelRequested
    {
        get => GetPropertyValue<EventCallback>();
        set => SetPropertyValue(value);
    }

    public override Type ComponentType => typeof(EmployeeDetailView);
}
