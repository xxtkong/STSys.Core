using System;
using System.Collections.Generic;
using System.Text;

namespace STSys.Core.Registry
{
    public interface IRegistryHost : IManageServiceInstances, IManageHealthChecks
    {
    }
}
