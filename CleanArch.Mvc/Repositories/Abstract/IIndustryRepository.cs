using CleanArch.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Mvc.repositories.Abstract
{
    interface IIndustryRepository
    {
        IEnumerable<Industry> IndustryList();
        Industry GetIndustry(int IndustryId);
        bool InsertIndustry(Industry Industry);
        Industry DeleteIndustry(int IndustryId);
        Industry UpdateIndustry(int IndustryId);
    }
}
