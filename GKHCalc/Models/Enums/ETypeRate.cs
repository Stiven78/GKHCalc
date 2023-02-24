using GKHCalc.Models.Attributies;

namespace GKHCalc.Models.Enums
{
    public enum ETypeRate
    {
        [Localize("За человека")]
        PerPerson = 0,
        [Localize("За кв. метр")]
        PerSquareMeter,
        [Localize("За квартиру")]
        ForAnApartment,
        [Localize("По показаниям")]
        ByIndications,
    }
}
