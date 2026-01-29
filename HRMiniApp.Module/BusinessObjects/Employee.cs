using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.ExpressApp.ConditionalAppearance;
using System.Drawing;
using DevExpress.Persistent.Validation;

namespace HRMiniApp.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("HR Management")]
    public class Employee : BaseObject
    {
        public Employee(Session session) : base(session) { }

        private string firstName;
        private string lastName;
        private Department department;
        private bool isManager;

        [RuleRequiredField]
        public string FirstName
        {
            get => firstName;
            set => SetPropertyValue(nameof(FirstName), ref firstName, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetPropertyValue(nameof(LastName), ref lastName, value);
        }

        [Association("Department-Employees")]
        public Department Department
        {
            get => department;
            set => SetPropertyValue(nameof(Department), ref department, value);
        }

        public bool IsManager
        {
            get => isManager;
            set => SetPropertyValue(nameof(IsManager), ref isManager, value);
        }


        //[PersistentAlias("Concat(FirstName, ' ', LastName)")]
        //public string FullName
        //{
        //    get
        //    {
        //        object tmp = EvaluateAlias(nameof(FullName));
        //        return tmp?.ToString();
        //    }
        //}

        [Association("Employee-Tasks"), Aggregated]
        public XPCollection<TaskItem> Tasks => GetCollection<TaskItem>(nameof(Tasks));

    }

    

    // Appearance: Managers in bold
    [Appearance("ManagerBold",
        TargetItems = "*",
        Criteria = "IsManager = true",
        FontStyle = DevExpress.Drawing.DXFontStyle.Bold,
        Context = "ListView")]
    public class EmployeeAppearance { }
}