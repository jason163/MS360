using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.AspNetCore.Configuration
{
    public interface IMSControllerAssemblySettingBuilder
    {
        MSControllerAssemblySettingBuilder Where(Func<Type, bool> predicate);

        MSControllerAssemblySettingBuilder ConfigureControllerModel(Action<ControllerModel> configurer);
    }
}
