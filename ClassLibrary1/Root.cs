using Csla.Rules;
using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [Serializable]
    public class Root : BusinessBase<Root>
    {
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
        public string Name
        {
            get => GetProperty(NameProperty);
            set => SetProperty(NameProperty, value);
        }

        protected override void AddBusinessRules()
        {
            base.AddBusinessRules();
            BusinessRules.AddRule(new MyRule { PrimaryProperty = NameProperty });
        }

        [Fetch]
        private void Fetch() { }
    }

    [Serializable]
    public class Child : BusinessBase<Child>
    {
        public static readonly PropertyInfo<bool> GotContextProperty = RegisterProperty<bool>(nameof(GotContext));
        public bool GotContext
        {
            get => GetProperty(GotContextProperty);
            set => SetProperty(GotContextProperty, value);
        }

        public static readonly PropertyInfo<bool> GotDalProperty = RegisterProperty<bool>(nameof(GotDal));

        public bool GotDal
        {
            get => GetProperty(GotDalProperty);
            set => SetProperty(GotDalProperty, value);
        }
        

        [FetchChild]
        private void Fetch([Inject] ApplicationContext context, [Inject] ITestDal dal)
        {
            // breakpoint vvv
            GotContext = context != null;
            GotDal = dal != null;
        }
    }

    public class MyRule : Csla.Rules.BusinessRuleAsync
    {
        protected override async Task ExecuteAsync(IRuleContext context)
        {
            var portal = context.ApplicationContext.GetRequiredService<IChildDataPortal<Child>>();
            var child = await portal.FetchChildAsync();
            // breakpoint vvv
            var result = child.GotDal;
        }
    }
}
