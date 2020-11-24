using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ModButtons
{
    public class ModButton_Text
    {
        private string label;
        private Action a;
        public ModButton_Text(string label, Action a)
        {
            this.label = label;
            this.a = a;
        }

        public void DoButton()
        {
            a.Invoke();
        }

        public void DrawButton(Rect rect)
        {
            if (Widgets.ButtonText(rect, this.label))
            {
                this.DoButton();
            }
        }
    }
}
