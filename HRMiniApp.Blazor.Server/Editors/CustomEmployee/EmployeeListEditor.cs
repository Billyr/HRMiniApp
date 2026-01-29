using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using HRMiniApp.Module.BusinessObjects;
using Microsoft.AspNetCore.Components;
using System.Collections;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Utils;

[ListEditor(typeof(Employee))]
public class EmployeeListEditor : ListEditor, IComponentContentHolder, IControlOrderProvider, IComplexListEditor
{
    private XafApplication _application;
    private CollectionSourceBase _collectionSource;

    private RenderFragment _componentContent;
    private Employee[] selectedObjects = Array.Empty<Employee>();
    public EmployeeListViewModel ComponentModel { get; private set; }


    public void Setup(CollectionSourceBase collectionSource, XafApplication application)
    {
        _application = application;
        _collectionSource = collectionSource;
    }


    public RenderFragment ComponentContent
    {
        get
        {
            _componentContent ??= ComponentModelObserver.Create(ComponentModel, ComponentModel.GetComponentContent());
            return _componentContent;
        }
    }

    public EmployeeListEditor(IModelListView model) : base(model) { }


    public int GetIndexByObject(object obj)
    {
        var items = ListHelper.GetList(ComponentModel.Data);
        var index = items.IndexOf(obj);
        if (index == int.MinValue)
        {
            index = -1;
        }
        return index;
    }

    


    public object GetObjectByIndex(int index)
    {
        if (index == 0)
            return null;

        var items = ListHelper.GetList(ComponentModel?.Data);

        return items != null && index <= items.Count
        ? items[index - 1]
        : null;
    }

    public IList GetOrderedObjects()
    {
        var orderedObjects = new List<object>();
        var items = ListHelper.GetList(ComponentModel.Data);
        for (var rowVisibleIndex = 0; rowVisibleIndex < items.Count; ++rowVisibleIndex)
        {
            var record = items[rowVisibleIndex];
            if (record != null)
            {
                orderedObjects.Add(record);
            }
        }
        return orderedObjects;
    }



    public override SelectionType SelectionType => SelectionType.Full;

    public override IList GetSelectedObjects()
    {
        return selectedObjects;
    }
    


    public override void BreakLinksToControls()
    {
        AssignDataSourceToControl(null);
        base.BreakLinksToControls();
    }
    public override void Refresh()
    {
        UpdateDataSource(DataSource);
    }





    protected override object CreateControlsCore()
    {
        ComponentModel = new EmployeeListViewModel();
        ComponentModel.ItemClick = EventCallback.Factory.Create<Employee>(this, (item) => 
        {
            selectedObjects = new Employee[] { item };
            OnSelectionChanged();
            // When an employee is clicked, select it and open DetailView
            //OnProcessSelectedItem();
            OpenCustomEmployeeDetailView(item);
        });

        return ComponentModel;
    }

    

    private void OpenCustomEmployeeDetailView(Employee employee) 
    {
        var objectSpace = _collectionSource.ObjectSpace.CreateNestedObjectSpace();
        var employeeInOs = objectSpace.GetObject(employee);

        var detailView = _application.CreateDetailView(
            objectSpace,
            "Employee_Custom_DetailView",
            true ,// isRoot
            employeeInOs
         );

        detailView.ViewEditMode = ViewEditMode.Edit;

        ShowCustomDetailView(detailView);

    }

    private void ShowCustomDetailView(DetailView detailView)
    {
        var showViewParameters = new ShowViewParameters(detailView)
        {
            TargetWindow = TargetWindow.NewWindow,
            Context = TemplateContext.View,
            
        };
        _application.ShowViewStrategy.ShowView(showViewParameters, new ShowViewSource(null, null));
    }



    protected override void AssignDataSourceToControl(object dataSource)
    {

        if (ComponentModel is null)
            return;

        
        if (ComponentModel.Data is IBindingList oldBinding) 
            oldBinding.ListChanged -= BindingList_ListChanged;
        
        UpdateDataSource(dataSource);
        
        if (dataSource is IBindingList newBinding) 
            newBinding.ListChanged += BindingList_ListChanged;
        
    }

    private void UpdateDataSource(object dataSource)
    {
        if (ComponentModel is null)
            return;

        if (dataSource is not IEnumerable)
        {
            ComponentModel.Data = [];
            return;
        }
        
        ComponentModel.Data = (dataSource as IEnumerable)?.OfType<Employee>().ToList();
    }

    private void BindingList_ListChanged(object sender, ListChangedEventArgs e)
    {
        UpdateDataSource(DataSource);
    }

    
}
