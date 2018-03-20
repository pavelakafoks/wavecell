using System.Threading.Tasks;

namespace WavecellSmsCore
{
    public static class WavecellSms
    {
        public static async Task<string> WavecellSmsDeliveryReportTest(string url)
        {
            var body = @"<DeliveryReport version=""3"">
                  <UMID>371e8f64-195b-e711-8144-020897df54591-notToBeSent</UMID>
                  <DateTimeStamp>2017-06-27T09:17:08.7980379+00:00</DateTimeStamp>
                  <Status>RECEIVED FOR PROCESSING</Status>
                  <Reason />
                  <Source>Wavecell</Source>
                  <SubAccountId>wavecell_test3</SubAccountId>
                  <Attempt>0</Attempt>
                  <ErrorCode>0</ErrorCode>
                  <Destination>6512345678</Destination>
                  <Price>0.012</Price>
                  <Currency>EUR</Currency>
                  <ClientMessageId>123</ClientMessageId>
                </DeliveryReport>";

            var response = Web.PostRequest(url, body, null);

            return await response;
        }

    }
}
