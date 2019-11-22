using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Admin.Application.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
