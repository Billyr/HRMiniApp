using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace HRMiniApp.Module.BusinessObjects.CustomList
{
    [DefaultClassOptions]
    public class PictureItem(Session session) : BaseObject(session), IPictureItem
    {
        private byte[] image;
        private string text;

        [ImageEditor]
        public byte[] Image
        {
            get { return image; }
            set { SetPropertyValue(nameof(Image), ref image, value); }
        }
        public string Text
        {
            get { return text; }
            set { SetPropertyValue(nameof(Text), ref text, value); }
        }
    }
}
