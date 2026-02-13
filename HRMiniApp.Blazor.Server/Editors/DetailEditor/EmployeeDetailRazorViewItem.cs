using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Blazor.Components;
using Microsoft.AspNetCore.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Blazor.Editors;
using HRMiniApp.Module.BusinessObjects;
using System.Threading.Channels;
using HRMiniApp.Blazor.Server.Components;


//[ViewItem(typeof(IModelViewItem))]
public class EmployeeDetailRazorViewItem(Type objectType, IModelViewItem model) 
    : ViewItem(objectType, model.Id) , IComponentContentHolder
{
    private EmployeeDetailViewModel _model;
    private RenderFragment _content;

    //public Employee Employee => View?.CurrentObject as Employee;

    //public RenderFragment ComponentContent
    //    => _content ??= ComponentModelObserver.Create(
    //        _model,
    //        _model.GetComponentContent()
    //    );

    protected override object CreateControlCore()
    {
        _model = new EmployeeDetailViewModel
        {
            View = View,
            Employee = (Employee)View.CurrentObject,
            SaveRequested = EventCallback.Factory.Create(this, Save),
            CancelRequested = EventCallback.Factory.Create(this, Cancel)
        };

        //return _model;

        //_model = new EmployeeDetailViewModel
        //{
        //    View = View,
        //    Employee = View.CurrentObject as Employee
        //};

        return (RenderFragment)((builder) =>
        {
            builder.OpenComponent<EmployeeDetailView>(0);
            builder.AddAttribute(1, "Model", this);
            builder.CloseComponent();
        });

        //EnsureModel();
        //return ComponentModel;
    }
    public RenderFragment ComponentContent => (RenderFragment)Control;


    //protected override void OnControlCreated()
    //{
    //base.OnControlCreated();

    //EnsureModel();

    //ComponentModel.View = View;

    //ComponentModel.Employee = (Employee)View.CurrentObject;

    //ComponentModel.SaveRequested = EventCallback.Factory.Create(this, Save);

    //ComponentModel.CancelRequested = EventCallback.Factory.Create(this, Cancel);
    //}

    private void Save()
    {
        View.ObjectSpace.CommitChanges();
    }

    private void Cancel()
    {
        View.ObjectSpace.Rollback();
    }

    //public RenderFragment ComponentContent
    //{
    //get
    //{
    //    _componentContent ??=
    //        ComponentModelObserver.Create(EnsureAndGetModel(), ComponentModel.GetComponentContent());
    //    return _componentContent;
    //}
    //}

    //private void EnsureModel()
    //{
    //    if (ComponentModel != null)
    //        return;

    //    ComponentModel = new EmployeeDetailViewModel();


    //}

    //private EmployeeDetailViewModel EnsureAndGetModel()
    //{
    //    EnsureModel();
    //    return ComponentModel;
    //}

}
