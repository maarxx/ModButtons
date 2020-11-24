using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ModButtons
{
    public class MainTabWindow_ModButtons : MainTabWindow
    {
        public static List<List<ModButton_Text>> columns = new List<List<ModButton_Text>>();
        public MainTabWindow_ModButtons()
        {
            //base.forcePause = true;
        }


        private const float BUTTON_HEIGHT = 50f;
        private const float BUTTON_WIDTH = 250f;
        private const float BUTTON_SPACE = 10f;

        public override Vector2 InitialSize
        {
            get
            {
                int numColumns = columns.Count;
                int numRows = 0;
                int columnCount = 0;
                foreach (List<ModButton_Text> column in columns)
                {
                    columnCount = column.Count;
                    if (columnCount > numRows)
                    {
                        numRows = column.Count;
                    }
                }
                return new Vector2(250f * numColumns, (BUTTON_HEIGHT + BUTTON_SPACE) * (numRows + 1));
            }
        }

        public override MainTabWindowAnchor Anchor =>
            MainTabWindowAnchor.Right;

        public override void DoWindowContents(Rect canvas)
        {
            base.DoWindowContents(canvas);
            Text.Font = GameFont.Small;
            foreach (List<ModButton_Text> column in columns)
            {
                int i = 0;
                foreach (ModButton_Text button in column)
                {
                    Rect nextButton = new Rect(canvas);
                    nextButton.y = i * (BUTTON_HEIGHT + BUTTON_SPACE);
                    nextButton.height = BUTTON_HEIGHT;

                    button.DrawButton(nextButton);

                    i++;
                }
            }
        }
    }
}
