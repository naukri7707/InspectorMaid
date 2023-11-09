namespace Naukri.InspectorMaid.Samples
{
    public class CardSlotAttribute : SlotAttribute
    {
        public CardSlotAttribute(string templateName) : base(templateName)
        {
        }

        public const string kDefaultBGColor = "#434343";
    }
}
