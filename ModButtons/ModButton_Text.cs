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
        private Func<String> getLabel;
        private Action doButton;
        public ModButton_Text(Func<String> getLabel, Action doButton)
        {
            this.getLabel = getLabel;
            this.doButton = doButton;
        }

        public string GetLabel()
        {
            return getLabel.Invoke();
        }

        public void DoButton()
        {
            doButton.Invoke();
        }

        public void DrawButton(Rect rect)
        {
            if (Widgets.ButtonText(rect, this.GetLabel()))
            {
                this.DoButton();
            }
        }
    }
}
