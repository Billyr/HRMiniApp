using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using HRMiniApp.Module.BusinessObjects;
using Microsoft.AspNetCore.Components;

namespace HRMiniApp.Blazor.Server.Components.TaskItemWizard;

public interface IModelTaskItemViewItem : IModelViewItem { }
[ViewItem(typeof(IModelTaskItemViewItem))]
public class TaskItemWizardViewItem : ViewItem//, IComponentContentHolder
{
    //private RenderFragment _componentContent;
    //public TaskItemWizardComponentModel ComponentModel { get; private set; }
    //public RenderFragment ComponentContent
    //{
    //    get
    //    {
    //        _componentContent ??= ComponentModelObserver.Create(ComponentModel, ComponentModel.GetComponentContent());
    //        return _componentContent;
    //    }
    //}

    private PropertyEditor dueDateEditor;


    public TaskItemWizardViewItem(IModelTaskItemViewItem model, Type objectType)
        : base(objectType, model.Id)
    {
    }

    public TaskItemAdapter TaskItemAdapter { get; private set; }
    
    protected override object CreateControlCore()
    {
        var detailView = (DetailView)View;

        // 1️⃣ Find DueDate in the model
        IModelMemberViewItem member =
            detailView.Model.Items
                .OfType<IModelPropertyEditor>()
                .FirstOrDefault(x => x.PropertyName == nameof(TaskItem.DueDate));

        // 2️⃣ Let XAF create the editor (RESPECTS MonthYearEditor)
        //dueDateEditor = View.CreateItem<PropertyEditor>(member);

        //dueDateEditor. Setup(View.ObjectSpace, View.CurrentObject);
        dueDateEditor.ReadValue();

        TaskItemAdapter = new TaskItemAdapter(new
            TaskItemWizardComponentModel
            (
                View.ObjectSpace,
                View.CurrentObject as TaskItem
            ));
        return TaskItemAdapter;    
    }


    protected override void OnCurrentObjectChanged()
    {
        base.OnCurrentObjectChanged();
        if (TaskItemAdapter?.ComponentModel is not null)
        {
            TaskItemAdapter.ComponentModel.TaskItem = View.CurrentObject as TaskItem;
        }
    }

    //public Type ComponentType => typeof(TaskItemWizard);


}
