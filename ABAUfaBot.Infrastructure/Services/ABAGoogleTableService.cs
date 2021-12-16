using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using ABAUfaBot.Application.Interfaces;

namespace ABAUfaBot.Infrastructure.Services
{
    public class ABAGoogleTableService : IABAGoogleTableService
    {
        private string _serviceActEmail = string.Empty;
        private string _serviceAppName = string.Empty;
        private string _privateKey = string.Empty;
        private SheetsService currentSheetsService = null;

        public ABAGoogleTableService(IABAGoogleTableServiceOptions options)
        {
            _serviceActEmail = options.ServiceActEmail;
            _serviceAppName = options.ServiceAppName;
            _privateKey = options.PrivateKey;

            currentSheetsService = GetService();
        }

        private SheetsService GetService()
        {
            if (currentSheetsService != null)
            {
                return currentSheetsService;
            }
            string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };

            var serviceAccountCredentialInitializer = new ServiceAccountCredential.Initializer(_serviceActEmail)
            {
                User = _serviceActEmail,
                Scopes = new[] { SheetsService.Scope.SpreadsheetsReadonly }
            }.FromPrivateKey(_privateKey);

            var googleCredential = new ServiceAccountCredential(serviceAccountCredentialInitializer);

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = googleCredential,
                ApplicationName = _serviceAppName,
            });

            currentSheetsService = service;
            return currentSheetsService;
        }

        //private SheetsService GetService()
        //{
        //    string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };

        //    const string SERVICE_ACCT_EMAIL = "abaufabot@testproject1-254906.iam.gserviceaccount.com";
        //    //Generate your .p12 key in the Google Developer Console and associate it with your project.
        //    //var certificate = new X509Certificate2(("Key.p12", "notasecret", X509KeyStorageFlags.Exportable);

        //    var serviceAccountCredentialInitializer = new ServiceAccountCredential.Initializer(SERVICE_ACCT_EMAIL)
        //    {
        //        User = "abaufabot@testproject1-254906.iam.gserviceaccount.com", // A user with administrator access.
        //        Scopes = new[] { SheetsService.Scope.SpreadsheetsReadonly }
        //    }.FromPrivateKey("-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDMMocgbolzVB5e\nE95XfTlTAoniHjJUsO0DO6KQaIQD8UyguhnFFBGGmzc0gCM9oJmEFaj4Sj4VJXSZ\n1dQkrrzMhm+9w+BDJtygGhTrch7tS6UPZIqnpYOIiM0NWns4ZLzmC04BUIV44mHU\n99eKt2b/LkqKpxMmPa/qCIDJMVVTzXj388tsT8BteRLzmDCJdStr8+Y41vqM4hTu\nYYakrVhf6naoi+jHs/3tSbP1aMwRO50nTtFYSmHPnlBRi4zVgtv3KDmkswYzZgJm\n0G56P6P7g0+1Icr28/o5f3qiO+PJ8e7Tk4SLnuwAvpXaly1Fz6gDd1UXiorWPZGU\nPZGm3iknAgMBAAECggEAZGlYX09b0dWElViJ1lXisXonGYUl1NWnxxY1K3PprxKi\nTssUzv++WoXLEMsOCUkHFJeeHnJLsxRXESrABkXS23QkUJmYlwzuIuCQdvMIWEIB\nad9T+3p9gs9anf1naGTJKwpWEnlpGPehihtR54mmYUd/Kk1cMkrVTW1e/xB+WBVq\nDYj+qdm7NL7XfHusCZtUckOEgt04PAcU9p/7zQk66X3Cpxa2uE/732cR3kZiMzow\nKPhJvRRX8jlTIDckvHd3BaOBpo4SYvTqFBwrCipVjIlL4gyl2IPABuTUX6Oxg83F\nqgP5rHzXaLOQtzlWheing29EqHg43Rl6ALMskkUN4QKBgQDwAqWdAW+sgjERGUi7\n+LXJDJP/I8l/wjtt3LUjaF2BzgcU4LgmOwwXCZjWppKE6YyQCp2DOIkq8JQblPld\nX/y+vcuEzX5IQgEFkdfzEi1s2OnuPrP/xdWBS+1321hKBlmMntA6b2Q/WnFAS2gA\nL2tEkMMtL1IrAyiYf6MetJpRlwKBgQDZzRghkuZ0w6ZoYP5i4XG4AiHhZDyyKCk/\nDJ0bzl8bNIl7hvLQLjdWw8QL1tB9vzKolXz1dkjFw9rDhPimof+wFd+nuaZgV7rp\n7ww0d5L9/VQqE6U3pzZpBQuDyTdNORhueQiPgqBu8m0hG+vnQsWbgXTykU0/YU9t\n8jClN9q28QKBgQCdaL8Bd/2r4D8Z/cEsNvPShgNSZEA1IEglx4itTjd1eJBAaxmb\nSUKmoU6yCNEzhpD/r1aaxyt/FAWvCUd6rAdxebzOvo9CCLfu1TYSXyuXpbPW4xze\ndPuQLyHxZ9RByGRWy5m5mXDf9AsupcXxySfK8j5vlgeH2ix3x85NxxkmxQKBgCnO\nuKcZL6uSMssucyY/6DhOEHrXZt873k7/+NhxkMgEGa/gg5N6i5zYDzXGklbQ8MRz\njX0Aq49qvP9y8tfpmM8QI9JqTImJzZNCE7GukkS28ATzqG86ZbNbCI7PfRIRt6Ld\nEMubY3hoiJImbe4CXzQucWhug8l6wGh2aOgOBKnBAoGBAO1vTGLjTk6YtLVPp/aF\ntpXkXzChlxUA9U/HakqWRMIQ5smz/++fqd+Vj8xXkF3mPPXk+LPDA/vkFm1gpSLt\nOFrN9jjZ0dD/MNFq6UVo3JbeEbUh9OT7SvP+xDMJzst3XDXN0Q4Nlt4PmQsOa996\nsA+7gAlYTqNm6QQLInbgk3Jy\n-----END PRIVATE KEY-----");

        //    var googleCredential = new ServiceAccountCredential(serviceAccountCredentialInitializer);

        //    var service = new SheetsService(new BaseClientService.Initializer()
        //    {
        //        HttpClientInitializer = googleCredential,
        //        ApplicationName = "ABAUfaBot",
        //    });

        //    return service;
        //}

        private IList<IList<Object>> ReadGoogleSheet(string spreadsheetId, string range)
        {
            var tableService = this.GetService();

            SpreadsheetsResource.ValuesResource.GetRequest request =
                    tableService.Spreadsheets.Values.Get(spreadsheetId, range);

            return request.Execute().Values;
        }

        public async Task<IList<IList<Object>>> ReadGoogleSheetAsync(string id, string range)
        {
            return await Task.Run(() => ReadGoogleSheet(id, range));
        }
    }
}
