using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Components.Models;
using HRMiniApp.Module.BusinessObjects;

namespace HRMiniApp.Blazor.Server.Components.TaskItemWizard;
public class TaskItemWizardComponentModel : ComponentModelBase
{
    public IObjectSpace ObjectSpace { get; }
    public TaskItem TaskItem { get; set; }

    public int CurrentStep
    {
        get => GetPropertyValue<int>();
        set => SetPropertyValue(value);
    }

    public TaskItemWizardComponentModel(IObjectSpace objectSpace, TaskItem taskItem)
    {
        ObjectSpace = objectSpace;
        TaskItem = taskItem;
        CurrentStep = 0;
    }

    public void NextStep()
    {
        CurrentStep++;
    }

    public void PreviousStep()
    {
        CurrentStep--;
    }

    public void Save()
    {
        ObjectSpace.CommitChanges();
    }

    //public override Type ComponentType => typeof(TaskItemWizard);


}
