
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.BaseImpl;
using HRMiniApp.Blazor.Server.Editors.CustomList;
using System.ComponentModel;

namespace HRMiniApp.Blazor.Server;

[ToolboxItemFilter("Xaf.Platform.Blazor")]
// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class HRMiniAppBlazorModule : ModuleBase {
    public HRMiniAppBlazorModule() 
    {
        DataAccessModeHelper.RegisterEditorSupportedModes(typeof(BlazorCustomListEditor), [CollectionSourceDataAccessMode.Client]);
    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
        return ModuleUpdater.EmptyModuleUpdaters;
    }
    public override void Setup(XafApplication application) {
        base.Setup(application);

    }

}
