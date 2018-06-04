using System.Xml.Serialization;

namespace Ticket.Infrastructure.Ctrip.Response
{
    [XmlRoot("response")]
    public class VerifyOrderResponse
    {
        public HeaderResponse header { get; set; }
        public VerifyOrderBodyRespose body { get; set; }
    }

    public class VerifyOrderBodyRespose
    {
        public int inventory { get; set; }
    }
}
