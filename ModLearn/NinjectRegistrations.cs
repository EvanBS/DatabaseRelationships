using ModLearn.Models;
using Ninject.Modules;

namespace ModLearn
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<TeamRepository>().WithPropertyValue("context", new ApplicationDbContext());
        }
    }
}