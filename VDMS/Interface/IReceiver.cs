using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.Interface
{
    interface IReceiver
    {
        IEnumerable<ReceiverViewModel> GetAll();

        IEnumerable<ReceiverViewModel> GetAvailable();

        bool Save(Receiver viewModel);
        string Delete(int id);

        bool Edit(int id, Receiver receiver);

        ReceiverViewModel Detail(int id);

        ReceiverViewModel Create();
    }
}
