
using Kendo.Mvc.UI;
using Skynet.Data.Models;
using Skynet.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Service.Interfaces
{
    public interface IDispatchBoard
    {
        List<string> NumberOfJobsByStatus();

        GridModel GetMainCallSlipData([DataSourceRequest]DataSourceRequest request, CallSlipModel model);
        DailyJobStatusModel JobStatusReport(bool InState, bool OutOfState, bool Citibank, bool Aiss, bool Project);
        CallSlipModel GetJobDetailsById(long JobId, string PreviousJobId);
        TechContractorList GetContractorsByJobId(string JobId);
        TablesList GetTablesDataByJobId(TableDataModel param);
        NotesDocumentsModel GetNotesAndDocumentsByJobId(string callslipId);
        ProgressBarModel GetJobProgressBarDetails(string CallslipId);
        List<JobStatusHistoryModel> JobStatusHistory(string CallslipId);
        MultiEstimatesPartsDetailsModel GetPartsDetails(string CallslipId);
        PartJsonModel GetPartsByCallSlipId(string CallSlipId, long EstimateNumber);
        void prepareJobPartModel(string title, JobPartModel jpm, JobPart jp, Job j);
        dropdownLists PrepareDropDowns();
        List<PartDropDown> GetAllParts(string query);
        JobPartModel GetPartDetails(string PartName,string CustomerName,string JobPartId);
        List<PaymentModel> GetPaymentsByJobId(string CallSlipId);
        List<CustomerCreditCardModel> GetPaymentMethodsByJobId(string CallSlipId);
    }
}
