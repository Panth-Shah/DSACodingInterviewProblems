using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class SnapShotArray
    {
        private readonly SnapShotType[] snapShotCollection = null;
        private readonly int[] setValueList = null;
        private int snap_id = 0;
        public SnapShotArray(int length)
        {
            this.snapShotCollection = new SnapShotType[length+1];
            this.snapShotCollection[0] = new SnapShotType();
            this.setValueList = new int[length];
        }

        public void Set(int index, int val)
        {

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
