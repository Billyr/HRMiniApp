using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;

namespace HRMiniApp.Blazor.Server.Components.TaskItemWizard
{
    public class TaskItemAdapter : IComponentContentHolder
    {
        private RenderFragment _componentContent;
        public TaskItemWizardComponentModel ComponentModel { get; set; }

        
        public TaskItemAdapter(TaskItemWizardComponentModel componentModel)
        {
            ComponentModel = componentModel;
        }


        public RenderFragment ComponentContent
        {
            get
            {
                _componentContent ??= ComponentModelObserver.Create(ComponentModel, TaskItemWizard.Create(ComponentModel));
                return _componentContent;
            }
        }


    }
}
