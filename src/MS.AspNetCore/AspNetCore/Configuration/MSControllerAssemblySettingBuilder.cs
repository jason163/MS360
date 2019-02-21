using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.AspNetCore.Configuration
{
    public class MSControllerAssemblySettingBuilder : IMSControllerAssemblySettingBuilder
    {
        private readonly MSControllerAssemblySetting _setting;

        public MSControllerAssemblySettingBuilder(MSControllerAssemblySetting setting)
        {
            _setting = setting;
        }

        public MSControllerAssemblySettingBuilder ConfigureControllerModel(Action<ControllerModel> configurer)
        {
            _setting.ControllerModelConfigurer = configurer;
            return this;
        }

        public MSControllerAssemblySettingBuilder Where(Func<Type, bool> predicate)
        {
            _setting.TypePredicate = predicate;
            return this;
        }
    }
}
