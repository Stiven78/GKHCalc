using GKHCalc.Models.Attributies;

namespace GKHCalc.Models.Enums
{
    public enum EMenuItem
    {
        [Localize("Пользователи")]
        User,
        [Localize("Квартиры")]
        Apartments,
        [Localize("Дома")]
        House,
        [Localize("Выход")]
        Exit,
    }
}
