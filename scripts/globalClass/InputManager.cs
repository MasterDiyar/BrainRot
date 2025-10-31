namespace benzo.scripts.globalClass;

using Godot;
using System;
using System.Collections.Generic;

public partial class InputManager : Node
{
    public event Action<string, InputEvent> OnRebind;

    private readonly string[] _moveActions = { "w", "a", "s", "d", "jw", "ja", "js", "jd" };

    public virtual Vector2 GetMovementVector()
    {
        return Vector2.Zero;
    }

    public void RebindAction(string actionName, InputEvent newEvent)
    {
        if (!InputMap.HasAction(actionName))
        {
            GD.PrintErr($"Action '{actionName}' not found in InputMap.");
            return;
        }

        InputMap.ActionEraseEvents(actionName);
        InputMap.ActionAddEvent(actionName, newEvent);
        OnRebind?.Invoke(actionName, newEvent);
    }
    
    
}
