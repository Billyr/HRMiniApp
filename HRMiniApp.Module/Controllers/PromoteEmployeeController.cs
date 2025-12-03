using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using HRMiniApp.Module.BusinessObjects;

namespace HRMiniApp.Module.Controllers
{
    public partial class PromoteEmployeeController : ObjectViewController<ListView, Employee>
    {

        private PopupWindowShowAction assignTaskAction { get; }
        private PopupWindowShowAction approveAction { get; }


        public PromoteEmployeeController()
        {

            // SimpleAction: Approve Employee
            approveAction = new PopupWindowShowAction(this, "ApproveEmployee", PredefinedCategory.Edit)
            {
                Caption = "Approve",
                ImageName = "Action_Grant",
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects
            };

            approveAction.CustomizePopupWindowParams += ApproveAction_CustomizePopupWindowParams;
            approveAction.Execute += ApproveAction_Execute;
            Actions.Add(approveAction);

            // PopupWindowShowAction: View Details
            PopupWindowShowAction showDetailsAction = new PopupWindowShowAction(this, "ShowEmployeeDetails", PredefinedCategory.View)
            {
                Caption = "Details",
                ImageName = "Action_ShowDetailView"
            };
            showDetailsAction.CustomizePopupWindowParams += ShowDetailsAction_CustomizePopupWindowParams;
            Actions.Add(showDetailsAction);

            assignTaskAction = new PopupWindowShowAction(this, "AssignTaskToEmployees", PredefinedCategory.Edit)
            {
                Caption = "Assign Task...",
                ImageName = "Action_New"
            };
            assignTaskAction.CustomizePopupWindowParams += AssignTask_CustomizePopupWindowParams;
            assignTaskAction.Execute += AssignTask_Execute;
            Actions.Add(assignTaskAction);

        }


        // --- Show popup with parameter object ---
        private void AssignTask_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            // Use a NEW ObjectSpace for parameters (domain component via NonPersistentObjectSpace)
            var paramOS = Application.CreateObjectSpace(typeof(TaskAssignmentParam));
            var param = paramOS.CreateObject<TaskAssignmentParam>();

            e.View = Application.CreateDetailView(paramOS, param, true);
            e.DialogController.SaveOnAccept = false; // we'll handle saving in Execute
        }

        private void ApproveAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            var os = Application.CreateObjectSpace(typeof(ApproveConfirmationParam));
            var param = os.CreateObject<ApproveConfirmationParam>();

            e.View = Application.CreateDetailView(os, param, true);

            // XAF automatically adds a DialogController here
            e.DialogController.SaveOnAccept = false;
        }

        // --- Create Task(s) for selected employees based on parameter object ---
        private void AssignTask_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var param = (TaskAssignmentParam)e.PopupWindowViewCurrentObject;
            if (param == null) return;

            var os = View.ObjectSpace;

            foreach (var emp in View.SelectedObjects.Cast<Employee>())
            {
                var task = os.CreateObject<TaskItem>();
                task.Employee = emp;
                task.Title = param.Title;
                task.Priority = param.Priority;
                task.DueDate = param.DueDate;
                // Notes not persisted in this simple TaskItem — extend TaskItem if you want Notes
            }

            os.CommitChanges();
            View.Refresh();
        }

        private void ApproveAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            // Step 1: show confirmation popup
            var os = View.ObjectSpace;

            foreach (var emp in View.SelectedObjects.Cast<Employee>())
            {
                emp.IsManager = !emp.IsManager; // example toggle
            }

            os.CommitChanges();
            View.Refresh();

        }

        private void ShowDetailsAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            if (View.SelectedObjects.Cast<Employee>().FirstOrDefault() is Employee selected)
            {
                // Create a new ObjectSpace for the detail view
                IObjectSpace detailObjectSpace = Application.CreateObjectSpace(typeof(Employee));

                // Retrieve the object from the new ObjectSpace
                Employee employeeInDetail = detailObjectSpace.GetObject(selected);

                // Create a DetailView with the new ObjectSpace
                e.View = Application.CreateDetailView(detailObjectSpace, employeeInDetail);
            }
        }


        protected override void OnActivated()
        {
            //base.OnActivated();
            //// Conditional UI example: enable actions only for admin users
            //foreach (var action in Actions)
            //{
            //    action.Active["AdminOnly"] = true;
            //}
        }



    }
}
