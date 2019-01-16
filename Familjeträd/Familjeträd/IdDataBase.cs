using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Familjeträd
{
    class IdDataBase
    {
        private List<int> idList;

        public void AddId(int[] idArr)
        {
            for (int i = 0; i < idArr.Length; i++)
            {
                idList.Add(idArr[i]);
            }
        }

        static void CheckParent(int[] parentId)
        {

        }

        static void CheckSiblings(int[] parentId)
        {

        }

    }
}
