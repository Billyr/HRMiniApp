using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Validation;
using DevExpress.XtraPrinting.Native;
using System;

namespace HRMiniApp.Module.BusinessObjects
{
    // DomainComponent = non-persistent parameter object for popup
    [DomainComponent]
    public class TaskAssignmentParam
    {
        [RuleRequiredField]
        public string Title { get; set; }

        public Priority Priority { get; set; } = Priority.Low;

        public DateTime? DueDate { get; set; }

        public string Notes { get; set; }
    }
}
