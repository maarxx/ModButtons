using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace ModButtons;

public class MainTabWindow_ModButtons : MainTabWindow
{
    private const float BUTTON_HEIGHT = 50f;
    private const float BUTTON_WIDTH = 250f;
    private const float BUTTON_SPACE = 10f;
    public static List<List<ModButton_Text>> columns = new List<List<ModButton_Text>>();

    public override Vector2 InitialSize
    {
        get
        {
            var numColumns = columns.Count;
            var maxRows = 0;
            foreach (var column in columns)
            {
                var rowsInColumn = column.Count;
                if (rowsInColumn > maxRows)
                {
                    maxRows = rowsInColumn;
                }
            }

            return new Vector2(
                ((BUTTON_WIDTH + BUTTON_SPACE) * numColumns) + (BUTTON_SPACE * 3),
                ((BUTTON_HEIGHT + BUTTON_SPACE) * maxRows) + (BUTTON_SPACE * 3)
            );
        }
    }

    public override MainTabWindowAnchor Anchor =>
        MainTabWindowAnchor.Right;

    public override void DoWindowContents(Rect canvas)
    {
        Text.Font = GameFont.Small;
        var col = 0;
        foreach (var column in columns)
        {
            var row = 0;
            foreach (var button in column)
            {
                var nextButton = new Rect(canvas)
                {
                    y = row * (BUTTON_HEIGHT + BUTTON_SPACE),
                    height = BUTTON_HEIGHT,
                    x = col * (BUTTON_WIDTH + BUTTON_SPACE),
                    width = BUTTON_WIDTH
                };

                button.DrawButton(nextButton);

                row++;
            }

            col++;
        }
    }
}