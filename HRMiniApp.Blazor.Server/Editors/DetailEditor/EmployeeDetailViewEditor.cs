//using DevExpress.ExpressApp;
//using DevExpress.ExpressApp.Editors;
//using DevExpress.ExpressApp.Blazor;
//using DevExpress.ExpressApp.Blazor.Components.Models;
//using HRMiniApp.Module.BusinessObjects;
//using Microsoft.AspNetCore.Components;
//using DevExpress.ExpressApp.Blazor.Components;


//[ViewItem(typeof(Employee), isDefault: true)]
//public class EmployeeDetailViewEditor : BlazorViewItem, IComponentContentHolder
//{
//    private RenderFragment content;
//    protected EmployeeDetailViewModel ComponentModel;

//    public RenderFragment ComponentContent =>
//        content ??= ComponentModelObserver.Create(
//            ComponentModel,
//            ComponentModel.GetComponentContent()
//        );

//    protected override void CreateControlsCore()
//    {
//        ComponentModel = new EmployeeDetailViewModel();

//        var os = View.ObjectSpace;
//        var employee = (Employee)View.CurrentObject;

//        ComponentModel.Employee = employee;
//        ComponentModel.IsNew = os.IsNewObject(employee);

//        ComponentModel.Departments =
//            os.GetObjects<Department>();

//        ComponentModel.SaveRequested =
//            EventCallback.Factory.Create(this, Save);

//        ComponentModel.CancelRequested =
//            EventCallback.Factory.Create(this, Cancel);
//    }

//    private void Save()
//    {
//        View.ObjectSpace.CommitChanges();
//        View.Close();
//    }
    

//    private void Cancel()
//    {
//        View.ObjectSpace.Rollback();
//        View.Close();
//    }

//    public override void BreakLinksToControl()
//    {
//        ComponentModel = null;
//        content = null;
//        base.BreakLinksToControl();
//    }
//}
