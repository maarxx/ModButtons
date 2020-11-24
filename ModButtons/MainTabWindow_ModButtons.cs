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
                int maxRows = 0;
                int rowsInColumn;
                foreach (List<ModButton_Text> column in columns)
                {
                    rowsInColumn = column.Count;
                    if (rowsInColumn > maxRows)
                    {
                        maxRows = rowsInColumn;
                    }
                }
                return new Vector2(
                    ((BUTTON_WIDTH + BUTTON_SPACE) * (numColumns)) + (BUTTON_SPACE * 3),
                    ((BUTTON_HEIGHT + BUTTON_SPACE) * (maxRows)) + (BUTTON_SPACE * 3)
                );
            }
        }

        public override MainTabWindowAnchor Anchor =>
            MainTabWindowAnchor.Right;

        public override void DoWindowContents(Rect canvas)
        {
            base.DoWindowContents(canvas);
            Text.Font = GameFont.Small;
            int col = 0;
            foreach (List<ModButton_Text> column in columns)
            {
                int row = 0;
                foreach (ModButton_Text button in column)
                {
                    Rect nextButton = new Rect(canvas);
                    nextButton.y = row * (BUTTON_HEIGHT + BUTTON_SPACE);
                    nextButton.height = BUTTON_HEIGHT;
                    nextButton.x = col * (BUTTON_WIDTH + BUTTON_SPACE);
                    nextButton.width = BUTTON_WIDTH;

                    button.DrawButton(nextButton);

                    row++;
                }
                col++;
            }
        }
    }
}
