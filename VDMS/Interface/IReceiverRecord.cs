using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDMS.Models;
using VDMS.ViewModel;

namespace VDMS.Interface
{
    interface IReceiverRecord
    {
        IEnumerable<ReceiverRecordViewModel> GetAll();

        bool Save(ReceiverRecord record);

        ReceiverRecordViewModel CreatrView();

        ReceiverRecordViewModel EditCreatrView(int id);

        bool Terminate(int id, ReceiverRecord record);
    }
}
