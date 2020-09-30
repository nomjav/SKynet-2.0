
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Service.Interfaces
{
    public interface ICallSlipService
    {
        DataSourceResult CallUsBackJobs([DataSourceRequest]DataSourceRequest request);
    }
}
