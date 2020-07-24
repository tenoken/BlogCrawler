using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Class.Abstracts
{
    public abstract class Report : IDisposable
    {
        private readonly List<Article> _articlesList;

        private bool _disposed = false;

        public Report()
        {
            //_articlesList = articlesList;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!this._disposed)
            {

                if (disposing)
                {
                    this.Dispose();
                }

                _disposed = true;

            }
        }
    }
}
