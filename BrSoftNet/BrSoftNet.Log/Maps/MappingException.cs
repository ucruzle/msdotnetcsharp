using BrSoftNet.Log.Structures;
using System.Collections.Generic;

namespace BrSoftNet.Log.Maps
{
    public class MappingException
    {
        public List<ChangesHeader> ChangeHeaders { get; set; }
        public List<ChangeItem> ChangeItems { get; set; }
        public List<ThrowingException> ThrowingExceptions { get; set; }
    }
}
