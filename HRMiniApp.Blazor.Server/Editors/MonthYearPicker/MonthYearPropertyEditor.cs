using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;
using System;

namespace BusinessSuite.Xaf.Blazor.Server.Editors
{
    [PropertyEditor(typeof(DateTime?), "MonthYearEditor", false)]
    public class MonthYearPropertyEditor : BlazorPropertyEditorBase
    {
        public MonthYearPropertyEditor(Type objectType, IModelMemberViewItem model)
            : base(objectType, model) { }

        // IMPORTANT: return a non-null adapter that renders the component
        protected override IComponentAdapter CreateComponentAdapter()
        {
            return new MonthYearAdapter(this);
        }

        // We don't use CreateViewComponentCore when using an adapter, so no override needed.
    }
}
