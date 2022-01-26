using System.Collections.Generic;
using UnityEngine;

public class CompositeMove : IMove
{
    private List<IMove> _moves = new List<IMove>();

    public void AddUnit(IMove unit)
    {
        _moves.Add(unit);
    }

    public void RemoveUnit(IMove unit)
    {
        _moves.Remove(unit);
    }

    public void Move(Vector3 point)
    {
        foreach(var move in _moves)
        {
            move.Move(point);
        }
    }
}
