using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace HRMiniApp.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem("HR Management")]
    public class Department : BaseObject
    {
        public Department(Session session) : base(session) { }

        private string name;
        public string Name
        {
            get => name;
            set => SetPropertyValue(nameof(Name), ref name, value);
        }

        [Association("Department-Employees")]
        public XPCollection<Employee> Employees
        {
            get { return GetCollection<Employee>(nameof(Employees)); }
        }
    }
}