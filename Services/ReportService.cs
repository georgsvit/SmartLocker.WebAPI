using Microsoft.Extensions.Localization;
using SmartLocker.WebAPI.Domain.RegisterNotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLocker.WebAPI.Services
{
    public class ReportService
    {
        private readonly IStringLocalizer localizer;

        public ReportService(IStringLocalizer localizer) => (this.localizer) = (localizer);

        public byte[] GetServiceRegisterReport(List<ServiceRegisterNote> notes) =>
            Encoding.UTF8.GetBytes(GenerateServiceRegisterReport(notes));

        private string GenerateServiceRegisterReport(List<ServiceRegisterNote> notes)
        {
            StringBuilder builder = new();

            List<string> reportContent = new()
            {
                $"{localizer["ServiceReportTitle"]} {DateTime.Now}\n"
            };

            foreach (ServiceRegisterNote note in notes) reportContent.Add(AddServiceNote(note));

            builder.Append(string.Join('\n', reportContent));

            builder.Append("\n-----------------------------------");

            return builder.ToString();
        }

        public byte[] GetViolationRegisterReport(List<ViolationRegisterNote> notes) =>
            Encoding.UTF8.GetBytes(GenerateViolationRegisterReport(notes));

        private string GenerateViolationRegisterReport(List<ViolationRegisterNote> notes)
        {
            StringBuilder builder = new();

            List<string> reportContent = new()
            {
                $"{localizer["ViolationReportTitle"]} {DateTime.Now}\n"
            };

            foreach (ViolationRegisterNote note in notes) reportContent.Add(AddViolationNote(note));

            builder.Append(string.Join('\n', reportContent));

            builder.Append("\n-----------------------------------");

            return builder.ToString();
        }

        public byte[] GetAccountingRegisterReport(List<AccountingRegisterNote> notes) =>
            Encoding.UTF8.GetBytes(GenerateAccountingRegisterReport(notes));

        private string GenerateAccountingRegisterReport(List<AccountingRegisterNote> notes)
        {
            StringBuilder builder = new();

            List<string> reportContent = new()
            {
                $"{localizer["AccountingReportTitle"]} {DateTime.Now}\n"
            };

            foreach (AccountingRegisterNote note in notes) reportContent.Add(AddAccountingNote(note));

            builder.Append(string.Join('\n', reportContent));

            builder.Append("\n-----------------------------------");

            return builder.ToString();
        }

        #region Report item generators

        private string AddServiceNote(ServiceRegisterNote note)
        {
            StringBuilder builder = new();

            builder.Append("-----------------------------------\n\n");
            builder.Append($"{localizer["Date"]}: {note.Date}\n\n");

            if (note.Cost == 0)
            {
                builder.Append($"{note.Tool.Name} {localizer["Tool was taken"]}\n");
            } else
            {
                builder.Append($"{note.Tool.Name} {localizer["Tool was maintened"]} {note.User.FirstName} {note.User.LastName}. {localizer["Cost"]}: {note.Cost} $.\n\n");
                builder.Append($"{localizer["Serviceman details"]}\n")
                   .Append($"  {localizer["Fullname"]}: {note.User.FirstName} {note.User.LastName}\n")
                   .Append($"  {localizer["AccessLevel"]}: {note.User.AccessLevel}\n");
            }            

            return builder.ToString();
        }

        private string AddViolationNote(ViolationRegisterNote note)
        {
            StringBuilder builder = new();

            builder.Append("-----------------------------------\n\n");
            builder.Append($"{localizer["Date"]}: {note.Date}\n\n");

            builder.Append($"{note.Tool.Name} {localizer["Tool was taken by"]} {note.User.FirstName} {note.User.LastName} {localizer["From"]} {note.Locker.Login}.\n\n");
            builder.Append($"{localizer["Violator details"]}\n")
                .Append($"  {localizer["Fullname"]}: {note.User.FirstName} {note.User.LastName}\n")
                .Append($"  {localizer["AccessLevel"]}: {note.User.AccessLevel}\n");

            return builder.ToString();
        }

        private string AddAccountingNote(AccountingRegisterNote note)
        {
            StringBuilder builder = new();

            builder.Append("-----------------------------------\n\n");
            builder.Append($"{note.Tool.Name} {localizer["Tool was taken by"]} {note.User.FirstName} {note.User.LastName} {localizer["At"]} {note.Date}.\n");

            if (note.ReturnDate is not null)
                builder.Append($"{localizer["Tool was returned at"]} {note.ReturnDate}.\n\n");
            else
                builder.Append('\n');

            builder.Append($"{localizer["User details"]}\n")
                .Append($"  {localizer["Fullname"]}: {note.User.FirstName} {note.User.LastName}\n")
                .Append($"  {localizer["AccessLevel"]}: {note.User.AccessLevel}\n");

            return builder.ToString();
        }

        #endregion
    }
}
