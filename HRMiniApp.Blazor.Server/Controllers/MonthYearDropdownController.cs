//using DevExpress.ExpressApp;
//using DevExpress.ExpressApp.Blazor.Editors;
//using DevExpress.ExpressApp.Editors;
//using HRMiniApp.Module.BusinessObjects;
//using Microsoft.AspNetCore.Components;

//public class MonthYearDropdownController : ViewController<DetailView>
//{
//    protected override void OnActivated()
//    {
//        base.OnActivated();

//        var editor = View.FindItem(nameof(TaskItem.DueDate)) as BlazorPropertyEditorBase;
//        if (editor != null)
//        {
//            editor.CustomizeViewItemControl += Customize;
//        }
//    }

//    private void Customize(object sender, CustomizeViewItemControlEventArgs e)
//    {
//        e.Control = builder =>
//        {
//            builder.OpenComponent<MonthYearDropdown>(0);
//            builder.AddAttribute(1, "Value", GetValue());
//            builder.AddAttribute(
//                2,
//                "ValueChanged",
//                EventCallback.Factory.Create<DateTime?>(this, SetValue)
//            );
//            builder.CloseComponent();
//        };
//    }

//    DateTime? GetValue()
//    {
//        return ((TaskItem)View.CurrentObject).DueDate;
//    }

//    void SetValue(DateTime? value)
//    {
//        var obj = (TaskItem)View.CurrentObject;
//        obj.DueDate = value;
//        ObjectSpace.SetModified(obj);
//    }
//}
