using DevExpress.ExpressApp.Blazor.Components.Models;
using HRMiniApp.Module.BusinessObjects.CustomList;
using Microsoft.AspNetCore.Components;

namespace HRMiniApp.Blazor.Server.Editors.CustomList
{
    public class PictureItemListViewModel : ComponentModelBase
    {
        public IEnumerable<IPictureItem> Data
        {
            get => GetPropertyValue<IEnumerable<IPictureItem>>();
            set => SetPropertyValue(value);
        }

        public EventCallback<IPictureItem> ItemClick
        {
            get => GetPropertyValue<EventCallback<IPictureItem>>();
            set => SetPropertyValue(value);
        }

        public EventCallback<IEnumerable<IPictureItem>> SelectionChanged
        {
            get => GetPropertyValue<EventCallback<IEnumerable<IPictureItem>>>();
            set => SetPropertyValue(value);
        }

        public override Type ComponentType => typeof(PictureItemListView);
    }
}
