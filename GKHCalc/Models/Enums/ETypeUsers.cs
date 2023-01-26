using GKHCalc.Models.Attributies;

namespace GKHCalc.Models.Enums
{
    public enum ETypeUsers
    {
        [Localize("Пользователь")]
        User,
        [Localize("Админ")]
        Admin,
        [Localize("Поставщик")] 
        Supplier,
        [Localize("Зав. склада")]
        WarehouseMan,
    }
}
