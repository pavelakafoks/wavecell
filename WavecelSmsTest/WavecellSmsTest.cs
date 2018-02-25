using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using WavecellSmsCore;

namespace WavecelSmsTest
{
    class WavecellSmsTest
    {
        private static SendSmsSingleResult TestSmsSingle()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var sendSmsSingleData = new SendSmsSingleData(
                new SendSmsSingleRequest
                {
                    Source = appSettings["testSource"],
                    DlrCallbackUrl = appSettings["dlrCallbackUrl"],
                    Destination = appSettings["testDestination1"],
                    Text = appSettings["text1"],
                    ClientMessageId = appSettings["clientMessageId1"]
                }
                , appSettings["apiKey"]
                , appSettings["urlSingle"]
                , appSettings["subAccountId"]);

            return WavecellSmsCore.WavecellSmsCore.SendSmsSingle(sendSmsSingleData);
        }

        private static SendSmsManyResult TestSmsMany()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var messages = new List<SendSmsSingleRequest>
            {
                new SendSmsSingleRequest
                {
                    Source = appSettings["testSource"],
                    DlrCallbackUrl = appSettings["dlrCallbackUrl"],
                    Destination = appSettings["testDestination1"],
                    Text = appSettings["text1"],
                    ClientMessageId = appSettings["clientMessageId1"]
                },
                new SendSmsSingleRequest
                {
                    Source = appSettings["testSource"],
                    DlrCallbackUrl = appSettings["dlrCallbackUrl"],
                    Destination = appSettings["testDestination2"],
                    Text = appSettings["text2"],
                    ClientMessageId = appSettings["clientMessageId2"]
                }
            };

            var sendSmsManyData = new SendSmsManyData(
                messages
                , appSettings["apiKey"]
                , appSettings["urlMany"]
                , appSettings["subAccountId"]);

            return WavecellSmsCore.WavecellSmsCore.SendSmsMany(sendSmsManyData);
        }


        static void Main()
        {
            // don't forget to add try/catch on production
            try
            {
                var res = TestSmsSingle();

                //var res = TestSmsMany();

                //var url = "http://localhost:49979/api/notification";         // local test
                //var url = "http://136.243.171.216:49979/api/notification";   // server test
                //var res = WavecellSmsCore.WavecellSms.WavecellSmsDeliveryReportTest(url);

                Debugger.Break();
            }
            catch(Exception exc)
            {
                Debugger.Break();
            }
        }
    }
}
