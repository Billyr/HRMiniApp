//using DevExpress.ExpressApp;
//using DevExpress.ExpressApp.Blazor.Components.Models;
//using HRMiniApp.Blazor.Server.Components;
//using HRMiniApp.Module.BusinessObjects;
//using Microsoft.AspNetCore.Components;

//public class EmployeeDetailRazorComponentModel : ComponentModelBase
//{
//    public View View { get; set; }
//    public Employee Employee => View?.CurrentObject as Employee;

//    public RenderFragment GetComponentContent()
//    {
//        return builder =>
//        {
//            builder.OpenComponent<EmployeeDetailView>(0);
//            builder.AddAttribute(1, "View", View);
//            builder.CloseComponent();
//        };
//    }
//}
