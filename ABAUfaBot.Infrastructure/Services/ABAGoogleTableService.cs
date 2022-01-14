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
