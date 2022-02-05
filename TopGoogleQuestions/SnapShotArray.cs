using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class SnapShotArray
    {
        private readonly List<SnapShotType> snapShotCollection = null;
        private readonly List<int> setValueList = null;
        public SnapShotArray(int length)
        {
            this.snapShotCollection = new List<SnapShotType>(length);
            this.snapShotCollection.Add(new SnapShotType());
            this.setValueList = new List<int>();
            List<string> L = new List<string>(new string[10]);
        }

        public void Set(int index, int val)
        {
            //this.setValueList.Add();
        }
    }
    public class SnapShotType
    {
        private readonly int snap_id;
        private readonly List<int> currentSnapShotVersion;

        public SnapShotType()
        {
            this.snap_id = -1;
            this.currentSnapShotVersion = new List<int>() { 0 };
        }
        public SnapShotType(int snap_id, List<int> currentSetValueArray)
        {
            this.snap_id = snap_id;
            this.currentSnapShotVersion = currentSetValueArray;
        }
    }
}
