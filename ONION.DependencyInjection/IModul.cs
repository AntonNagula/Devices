﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
namespace ONION.DependencyInjection
{
    public interface IModul
    {
        void Register(IUnityContainer container);
    }
}
