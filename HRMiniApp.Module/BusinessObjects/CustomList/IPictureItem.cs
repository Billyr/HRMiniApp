using System;
namespace HRMiniApp.Module.BusinessObjects.CustomList
{
    public interface IPictureItem
    {
        byte[] Image { get; }
        string Text { get; }
    }
}
