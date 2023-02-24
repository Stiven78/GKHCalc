using GKHCalc.Models.Attributies;

namespace GKHCalc.Models.Enums
{
    public enum EMenuApartamentItem
    {        
        [Localize("Показатели")]
        Indicators,
        [Localize("Платежи")]
        Payments,
        [Localize("Прописаные пользователи")]
        RegisteredUser,
        [Localize("Заполнение месяца")]
        FillingMonth
    }
}
