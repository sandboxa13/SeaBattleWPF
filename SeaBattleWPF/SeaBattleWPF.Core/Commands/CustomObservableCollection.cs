using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Threading;

namespace SeaBattleWPF.Core.Commands
{
    public class CustomObservableCollection<T> : ObservableCollection<T>
    {
        public override event NotifyCollectionChangedEventHandler CollectionChanged;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {   
            var eh = CollectionChanged;
            if (eh != null)
            {
                var dispatcher = (from NotifyCollectionChangedEventHandler nh in eh.GetInvocationList()
                    let dpo = nh.Target as DispatcherObject
                    where dpo != null
                    select dpo.Dispatcher).FirstOrDefault();

                if (dispatcher != null && dispatcher.CheckAccess() == false)
                {
                    dispatcher.Invoke(DispatcherPriority.DataBind, (Action)(() => OnCollectionChanged(e)));
                }
                else
                {
                    foreach (var @delegate in eh.GetInvocationList())
                    {
                        var nh = (NotifyCollectionChangedEventHandler) @delegate;
                        nh.Invoke(this, e);
                    }
                }
            }
        }
    }
}
