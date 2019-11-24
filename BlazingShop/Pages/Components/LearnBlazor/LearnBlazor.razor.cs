using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Pages.Components.LearnBlazor
{
    public class LearnBlazorBase : ComponentBase
    {
        protected string name = "Spark";
        protected string Welcome = "Time to learn".ToUpper();

        protected void getName()
        {
            name = "Thales";
        }
    }
}
