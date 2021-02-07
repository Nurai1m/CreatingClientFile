using Clients.BLL.IServices;
using Clients.DAL.IRepositories;
using ClosedXML.Excel;
using System;

namespace Clients.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repos;
        public ClientService(IClientRepository repos)
        {
            _repos = repos;
        }
        public string GenerateDocumentBySocialNumber(string SocialNumber)
        {
            try
            {
                var client = _repos.GetDataBySocialNumber(SocialNumber);
                if (client != null)
                {
                    var templatePath = Environment.CurrentDirectory + "\\Template\\example.xlsx";
                    var resultPath = Environment.CurrentDirectory + "\\Result\\" + client.SocialNumber + "_" + $@"{Guid.NewGuid()}.xlsx";

                    using (var workbook = new XLWorkbook(templatePath))
                    {
                        var worksheet = workbook.Worksheet(1);

                        worksheet.Cell(1, "B").Value = DateTime.Now;

                        var idCells = worksheet.CellsUsed(r => r.GetString() == "[ID]");
                        foreach (var cell in idCells)
                        {
                            cell.Value = client.Id;
                        }

                        var NameCells = worksheet.CellsUsed(r => r.GetString() == "[Name]");
                        foreach (var cell in NameCells)
                        {
                            cell.Value = client.Name;
                        }

                        var BirthDateCells = worksheet.CellsUsed(r => r.GetString() == "[BirthDate]");
                        foreach (var cell in BirthDateCells)
                        {
                            cell.Value = client.BirthDate;
                        }

                        var PhoneNumberCells = worksheet.CellsUsed(r => r.GetString() == "[PhoneNumber]");
                        foreach (var cell in PhoneNumberCells)
                        {
                            cell.Value = client.PhoneNumber;
                        }

                        var AddressCells = worksheet.CellsUsed(r => r.GetString() == "[Address]");
                        foreach (var cell in AddressCells)
                        {
                            cell.Value = client.Address;
                        }

                        var SocialNumberCells = worksheet.CellsUsed(r => r.GetString() == "[SocialNumber]");
                        foreach (var cell in SocialNumberCells)
                        {
                            cell.SetValue<string>(client.SocialNumber);
                        }

                        workbook.SaveAs(resultPath);
                    }
                    return "Клиент найден. Файл сохранен в папке Result";
                }
                else
                    return "Клиента с таким ИНН не существует в базе";
            }
            catch (Exception e)
            {
                return "Что-то пошло не так, попробуйте повторить";
            }
        }
    }
}
