using DevExpress.ExpressApp.DC;

namespace HRMiniApp.Module.BusinessObjects
{
    [DomainComponent]
    public class ApproveConfirmationParam
    {
        public string Message  => "Are you sure you want to approve the selected employees?";
    }
}
