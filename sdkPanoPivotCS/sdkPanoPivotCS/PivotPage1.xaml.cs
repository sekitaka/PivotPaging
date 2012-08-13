/* 
    Copyright (c) 2011 Microsoft Corporation.  All rights reserved.
    Use of this sample source code is subject to the terms of the Microsoft license 
    agreement under which you licensed this sample source code and is provided AS-IS.
    If you did not accept the terms of the license agreement, you are not authorized 
    to use this sample source code.  For the terms of the license, please see the 
    license agreement between you and Microsoft.
  
    To see all Code Samples for Windows Phone, visit http://go.microsoft.com/fwlink/?LinkID=219604 
  
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Diagnostics;

namespace sdkPanoPivotCS
{
    public partial class PivotPage1 : PhoneApplicationPage
    {
        public int currentIndex;
        public PivotItem backupItem = null;
        public List<string> list;

        public PivotPage1()
        {
            InitializeComponent();
            
            // create page list.
            list = new List<string>();
            list.Add("item1__");
            list.Add("item2__");
            list.Add("item3__");
            list.Add("item4__");
            list.Add("item5__");
            currentIndex = 2;       // default item index.
        }

        private void Pivot_LoadingPivotItem(object sender, PivotItemEventArgs e)
        {
            PivotItem nextItem;         // right item
            PivotItem prevItem;         // left item

            // set next & prev item
            if (e.Item == item1)
            {
                nextItem = item2;
                prevItem = item3;
            }
            else if (e.Item == item2)
            {
                nextItem = item3;
                prevItem = item1;
            }
            else
            {
                nextItem = item1;
                prevItem = item2;
            }

            // set current index
            if (backupItem == null)
            {
            }
            else
            {
                if (backupItem == item1)
                {
                    if (e.Item == item2) currentIndex++;
                    else currentIndex--;
                }
                else if (backupItem == item2)
                {
                    if (e.Item == item3) currentIndex++;
                    else currentIndex--;
                }
                else if (backupItem == item3)
                {
                    if (e.Item == item1) currentIndex++;
                    else currentIndex--;
                }
            }
            if (currentIndex < 0) currentIndex = list.Count() - 1;
            else if (currentIndex >= list.Count()) currentIndex = 0;

            // set current item
            if (currentIndex >= list.Count())
            {
                e.Item.Header = list[0];
            }
            else
            {
                e.Item.Header = list[currentIndex];
            }

            // set next item
            if ((currentIndex + 1) >= list.Count)
            {
                nextItem.Header = list[0];
            }
            else
            {
                nextItem.Header = list[currentIndex + 1];
            }

            // set prev item
            if ((currentIndex - 1) < 0)
            {
                prevItem.Header = list[list.Count - 1];
            }
            else
            {
                prevItem.Header = list[currentIndex - 1];
            }

            // backup selected item 
            backupItem = e.Item;
        }
    }
}
