C# library for wavecell.com.
Documentation: https://developer.wavecell.com/v1/api-documentation

 Created by: Pavel Samoylenko (https://github.com/pavelakafoks) 
 Created on: 2018-02-25


In this solution:
 - Send SMS - Single: dll
 - Send SMS - Many: dll
 - Delivery Reports (via Callback URL): Asp.Net core v2 WebApi
 - Test application: Console


"SubAccount" you can find in your cabinet in the section [Pricing] -> [Select sub-accounts] (Click to DropDown)
Authentication mode: "ApiKey Bearer Token"


When I created this solution I saw a message in the cabinet:
> About Callback URL
> If you want to setup your callback url, please contact operations.

and in Api documentation:
> We strongly recommend to set default callback url for your account (send request to support team) and use this field only when you want to overwrite default webhook.

!!! Callback parameter "dlrCallbackUrl" didn't work in my tests. This section will be updated after I receive information from support and set up a callback url for my account.
Also you can send emulation of notification via console test application.


You can use my test server (I deployed web app from this solution) to test delivery notification: http://136.243.171.216:49979


ToDo list:
 - Format html output in the notification receiver. Now we are showing just raw data
 - Realize all Api opportunities

Known problems:
1) If you see the error on build the "WavecellSmsDeliveryReports" project in Visual Studio:
"...project.assets.json' not found. Run a NuGet package restore to generate this file. WavecellSmsDeliveryReports..."
Solution: Run the command "dotnet restore" in the "Package Manager Console" and try again.