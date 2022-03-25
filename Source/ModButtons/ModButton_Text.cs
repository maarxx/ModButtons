using System;
using UnityEngine;
using Verse;

namespace ModButtons;

public class ModButton_Text
{
    private readonly Action doButton;
    private readonly Func<string> getLabel;

    public ModButton_Text(Func<string> getLabel, Action doButton)
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
        if (Widgets.ButtonText(rect, GetLabel()))
        {
            DoButton();
        }
    }
}