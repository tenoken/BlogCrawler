﻿using BlogCrawler.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Interfaces
{
    public interface ISpreadSheetReportService
    {
        bool CreateReport(List<Article> articlesList);
    }
}
