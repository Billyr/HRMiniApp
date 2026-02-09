using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;
using System;

namespace HRMiniApp.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("HR")]
    [XafDisplayName("Tasks")]
    [ImageName("BO_Task")]
    public class TaskItem : BaseObject
    {
        public TaskItem(Session session) : base(session) { }

        private string title;
        private Priority priority;
        private DateTime? dueDate;
        private Employee employee;

        [RuleRequiredField(CustomMessageTemplate ="Falta capturar el nombre de la tarea.")]
        [Size(200)]
        public string Title
        {
            get => title;
            set => SetPropertyValue(nameof(Title), ref title, value);
        }

        public Priority Priority
        {
            get => priority;
            set => SetPropertyValue(nameof(Priority), ref priority, value);
        }

        [ModelDefault("DisplayFormat", "MMMM yyyy")]
        [ModelDefault("EditMask", "MMMM yyyy")]
        [ModelDefault("AllowEdit", "True")]
        [ModelDefault("PropertyEditorType", "MonthYearEditor")]
        [ModelDefault("ImmediatePostData", "True")]
        [RuleRequiredField]
        public DateTime? DueDate
        {
            get => dueDate;
            set => SetPropertyValue(nameof(DueDate), ref dueDate, value);
        }

        [Association("Employee-Tasks")]
        //[RuleRequiredField]
        public Employee Employee
        {
            get => employee;
            set => SetPropertyValue(nameof(Employee), ref employee, value);
        }
    }
}
