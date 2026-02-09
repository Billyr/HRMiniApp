using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using Microsoft.AspNetCore.Components;

public sealed class MonthYearDummyAdapter : ComponentAdapterBase
{
    public override IComponentModel ComponentModel => null;

    public override object GetValue() => null;
    public override void SetValue(object value) { }

    public override void SetAllowEdit(bool allowEdit) { }
    public override void SetAllowNull(bool allowNull) { }
    public override void SetDisplayFormat(string displayFormat) { }
    public override void SetEditMask(string editMask) { }
    public override void SetEditMaskType(EditMaskType editMaskType) { }
    public override void SetIsPassword(bool isPassword) { }
    public override void SetMaxLength(int maxLength) { }
    public override void SetNullText(string nullText) { }
    public override void SetErrorIcon(ImageInfo imageInfo) { }
    public override void SetErrorMessage(string errorMessage) { }

    protected override RenderFragment CreateComponent()
        => builder => { };
}
