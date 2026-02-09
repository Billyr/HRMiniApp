using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using HRMiniApp.Blazor.Server.Components;
using HRMiniApp.Blazor.Server.Editors.MonthYearPicker;
using Microsoft.AspNetCore.Components;
using System;

namespace BusinessSuite.Xaf.Blazor.Server.Editors
{
    // Minimal adapter that renders the MonthYearDropdown and binds PropertyValue
    public class MonthYearAdapter : ComponentAdapterBase
    {
        private readonly BlazorPropertyEditorBase editor;
        private bool isReadOnly;
        private string errorMessage;

        public MonthYearAdapter(BlazorPropertyEditorBase editor)
        {
            this.editor = editor ?? throw new ArgumentNullException(nameof(editor));
            // Ensure adapter is initialized from the editor's settings
            SetAllowEdit(editor.AllowEdit);
            SetAllowNull(editor.AllowNull);
            SetDisplayFormat(editor.DisplayFormat);
            SetEditMask(editor.EditMask);
            SetEditMaskType(editor.EditMaskType);
            SetNullText(editor.NullText);
            SetErrorIcon(editor.ErrorIcon);
            SetErrorMessage(editor.ErrorMessage);
        }

        // The editor will read the property from the PropertyEditor via PropertyValue,
        // so GetValue/SetValue are not doing special tricks here.
        public override object GetValue()
        {
            return editor.PropertyValue; // object
        }

        public override void SetValue(object value)
        {
            // XAF → UI: when XAF pushes a value, update the editor rendering by calling editor.Refresh()
            editor.PropertyValue = value;
            // Request the PropertyEditor to re-render with its new PropertyValue
            editor.Refresh();
        }

        // Render the MonthYearDropdown and bind it to the PropertyValue
        protected override RenderFragment CreateComponent()
        {
            return builder =>
            {
                builder.OpenComponent(0, typeof(MonthYearPicker));
                // Pass current PropertyValue (as DateTime?)
                builder.AddAttribute(1, "Value", (DateTime?)editor.PropertyValue);
                // When the dropdown changes, set the PropertyValue on the editor.
                // Important: we do NOT call RaiseValueChanged() manually here.
                builder.AddAttribute(2,
                    "ValueChanged",
                    EventCallback.Factory.Create<DateTime?>(this, (DateTime? v) =>
                    {
                        // Set PropertyValue so BlazorPropertyEditorBase can handle the lifecycle
                        editor.PropertyValue = v;
                        // Refresh the editor UI to reflect the new value
                        editor.Refresh();
                        // Do NOT call RaiseValueChanged() — the PropertyEditor will decide when to write
                    }));
                // Provide read-only/error state
                //builder.AddAttribute(3, "IsReadOnly", isReadOnly);
                //builder.AddAttribute(4, "ErrorMessage", errorMessage);
                builder.CloseComponent();
            };
        }

        // Other adapter plumbing: mostly no-ops but required overrides
        public override void SetAllowEdit(bool allowEdit)
        {
            isReadOnly = !allowEdit;
            // No direct StateHasChanged — editor.Refresh() will be used when needed
        }

        public override void SetAllowNull(bool allowNull) { }
        public override void SetDisplayFormat(string displayFormat) { }
        public override void SetEditMask(string editMask) { }
        public override void SetEditMaskType(EditMaskType editMaskType) { }
        public override void SetErrorIcon(ImageInfo errorIcon) { }
        public override void SetErrorMessage(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }
        public override void SetIsPassword(bool isPassword) { }
        public override void SetMaxLength(int maxLength) { }
        public override void SetNullText(string nullText) { }

        public override IComponentModel ComponentModel => null;
    }
}
