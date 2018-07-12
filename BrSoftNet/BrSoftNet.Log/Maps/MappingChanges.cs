using BrSoftNet.Log.Structures;
using System;
using System.Collections.Generic;

namespace BrSoftNet.Log.Maps
{
    [Serializable]
    public class MappingChanges
    {
        public List<ChangesHeader> ChangeHeaders { get; set; }
        public List<ChangeItem> ChangeItems { get; set; }
    }
}
