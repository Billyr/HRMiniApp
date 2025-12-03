using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;


namespace HRMiniApp.Module.Extensions
{

    //public class AlwaysVisibleCalculator : IModelIsVisible
    //{
    //    public bool IsVisible(IModelNode node, string propertyName) => true;
    //}


    public interface IModelNavigationItemUrl
    {
        //[ModelBrowsable(typeof(AlwaysVisibleCalculator))]
        string Url { get; set; }
    }
}
