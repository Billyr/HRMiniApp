using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Blazor.Components;
using Microsoft.AspNetCore.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor;
using HRMiniApp.Module.BusinessObjects;


[ViewItem(typeof(IModelViewItem))]
public class EmployeeDetailRazorViewItem : ViewItem, IComponentContentHolder
{
    private RenderFragment _componentContent;
    private EmployeeDetailRazorComponentModel _model;

    public EmployeeDetailRazorViewItem()
        : base(null, null) // Provide default values for the required parameters
    {
    }

    public EmployeeDetailRazorViewItem(IModelViewItem model)
        : base(
            ((IModelObjectView)model.Parent).ModelClass.TypeInfo.Type,
            model.Id)
    {
    }


    public EmployeeDetailViewModel ComponentModel { get; private set; }

    protected override object CreateControlCore()
    {
        ComponentModel = new EmployeeDetailViewModel();
        return ComponentModel;
    }

    protected override void OnControlCreated()
    {
        base.OnControlCreated();

        ComponentModel.Employee = (Employee)View.CurrentObject;
    }

    public RenderFragment ComponentContent
    {
        get
        {
            _componentContent ??=
                ComponentModelObserver.Create(ComponentModel, ComponentModel.GetComponentContent());
            return _componentContent;
        }
    }
}
