using Ninject.Modules;
using TableLiveEdit.Core.Lib.Data;
using TableLiveEdit.Core.Models;

namespace TableLiveEdit.Core.Lib.Startup
{
    public class LinqToSqlDataContextModule : NinjectModule
    {
        private static IRepository BuildRepository()
        {
            var dataContext = new TableLiveEditDataContext();
            return new LinqToSqlRepository(dataContext);
        }

        public override void Load()
        {
            Bind<IRepository>().ToMethod(c => BuildRepository());
        }
    }
}
