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
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.XtraGauges.Core.Model;
using HRMiniApp.Module.Extensions;
using System.ComponentModel;
using System.Linq;

namespace HRMiniApp.Module;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class HRMiniAppModule : ModuleBase {
    public HRMiniAppModule() {
        //
        // HRMiniAppModule
        //
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Dashboards.DashboardsModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.StateMachine.StateMachineModule));
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.ValidationModule));
        DevExpress.Persistent.BaseImpl.AssemblyLoadHelper.ForceLoadXPOAssemblies();
    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
        ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
        return new ModuleUpdater[] { updater };
    }
    public override void Setup(XafApplication application) {
        base.Setup(application);
        
    }
    public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
        base.CustomizeTypesInfo(typesInfo);
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
    }

    public override void AddGeneratorUpdaters(ModelNodesGeneratorUpdaters updaters)
    {
        base.AddGeneratorUpdaters(updaters);
        updaters.Add(new RuntimeNavigationUpdater());

    }


    // ===============================
    // Runtime Navigation Updater
    // ===============================
    public class RuntimeNavigationUpdater : ModelNodesGeneratorUpdater<NavigationItemNodeGenerator>
    {
        public override void UpdateNode(ModelNode node)
        {
            var navItems = (IModelRootNavigationItems)node;

            // Add a new group at runtime
            IModelNavigationItem runtimeGroup = navItems.Items.AddNode<IModelNavigationItem>("RuntimeReports");
            runtimeGroup.Caption = "📊 Runtime Reports";

            // Add a child node pointing to an existing ListView
            IModelNavigationItem employeeNode = runtimeGroup.Items.AddNode<IModelNavigationItem>("EmployeeOverview");
            employeeNode.Caption = "Employee Overview (Dynamic)";

            // Only link if the view exists
            var appModel = navItems.Application as IModelApplication;
            if (appModel != null && appModel?.Views["Employee_ListView"] is IModelView employeeListView)
            {
                employeeNode.View = employeeListView;
            }
            else
            {
                // 🔥 Fallback: create a dummy navigation node without view
                employeeNode.Caption += " (No View Found)";
            }


            var employeePageNode = runtimeGroup.Items.AddNode<IModelNavigationItem>("EmployeePage");
            employeePageNode.Caption = "Employee Razor Page";

            ((IModelNavigationItemUrl)employeePageNode).Url = "/EmployeeOverview";

        }
    }


    public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders)
    {
        base.ExtendModelInterfaces(extenders);
        extenders.Add<IModelNavigationItem, IModelNavigationItemUrl>();
    }

    private void AddDynamicNavigation(XafApplication application)
    {
        //var modelRoot = application.Model as IModelRoot;
        //if (modelRoot != null)
        //{
        //    var navItems = modelRoot.Navigation.Items;

        //    // Add runtime group
        //    var runtimeGroup = navItems.AddNode<IModelNavigationItem>("RuntimeReports");
        //    runtimeGroup.Caption = "📊 Runtime Reports";

        //    // Add a ListView link if it exists
        //    if (application.Model.Views["Employee_ListView"] is IModelView employeeListView)
        //    {
        //        var employeeNode = runtimeGroup.Items.AddNode<IModelNavigationItem>("EmployeeOverview");
        //        employeeNode.Caption = "Employee Overview (Dynamic)";
        //        employeeNode.View = employeeListView;
        //    }

        //    // Add a Razor Page link
        //    var employeePageNode = runtimeGroup.Items.AddNode<IModelNavigationItem>("EmployeePage");
        //    employeePageNode.Caption = "Employee Razor Page";
        //    ((IModelNavigationItemUrl)employeePageNode).Url = "/EmployeeOverview";
        //}
    }

}
